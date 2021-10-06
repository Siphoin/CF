using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnitsSystem.StateSystem;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace UnitsSystem
{


    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(PhotonTransformView))]
    public class UnitBase : TeamObject, IPunObservable, IAnimationStateController, IGeterHit, IDPSObject, IRemoveObject, IInvokerMono
    {
        protected const string TAG_UNIT = "Unit";

        private const string PREFIX_NAME_DATA_ARMOR = "ArmorData_";
        private const string PREFIX_NAME_DATA_ATTACK = "AttackData_";

        private const string PATH_FOLBER_DATA_ARMOR = "Armor Data/";
        private const string PATH_FOLBER_DATA_ATTACK = "Attack Data/";

        private const string NAME_FOLBER_DATA = "Data/";

        protected AnimationState currentAnimationState = AnimationState.Idle;

        private IState currentState;

        private Vector3 currentPoint;

        private NavMeshAgent agent;

        protected Animator animator;

        private DynamicStatsUnit dynamicStats;

        private BlundersUnitsSettings blundersUnitsSettings;

        private Collider collider;

        public ArmorData ArmorData { get; private set; }

        public AttackData AttackData { get; private set; }

        private Dictionary<Type, IState> statesMap;

        public event Action onDeath;


        [Header("Äàííûå î þíèòå")]
        [SerializeField] private StatsUnit stats;

        public bool IsDead { get; private set; }

        public UnitBase TargetEnemy { get; protected set; }
        public StatsUnit Stats { get => stats; }
        public IState CurrentState { get => currentState; }
        public Vector3 CurrentPoint { get => currentPoint; }
        public NavMeshAgent Agent { get => agent; }
        protected Dictionary<Type, IState> StatesMap { get => statesMap; }

        protected void InitUnit()
        {
            if (stats == null)
            {
                throw new UnitException($"unit {name} not have stats data");
            }

            blundersUnitsSettings = Resources.Load<BlundersUnitsSettings>("Data/Others/UnitsBllundersSettings");

            LoadArmorData();
            LoadAttackData();

            InitStates();
            IniTeamObject();


            dynamicStats = new DynamicStatsUnit(stats);

            if (agent == null)
            {
                if (!TryGetComponent(out agent))
                {
                    throw new UnitException($"unit {name} not have component Nav Mesh Agent");
                }
            }

            if (animator == null)
            {
                if (!TryGetComponent(out animator))
                {
                    throw new UnitException($"unit {name} not have component Nav Animator");
                }
            }

            if (collider == null)
            {
                if (!TryGetComponent(out collider))
                {
                    throw new UnitException($"unit {name} not have component Colider");
                }
            }

#if UNITY_EDITOR
            name = name.Replace("(Clone)", string.Empty);
            name = $"{name}_Owner_{view.Owner.NickName}_{view.InstantiationId}";
#endif

            SetCurrentPoint(transform.position);


        }

        private void LoadArmorData()
        {
            string pathArmorData = $"{NAME_FOLBER_DATA}{PATH_FOLBER_DATA_ARMOR}{PREFIX_NAME_DATA_ARMOR}{stats.TypeArmor}";

            ArmorData = Resources.Load<ArmorData>(pathArmorData);

            if (!ArmorData)
            {
                throw new UnitException($"armor data unit {name} not found on path {pathArmorData}");
            }
        }

        private void LoadAttackData()
        {
            string pathAttackData = $"{NAME_FOLBER_DATA}{PATH_FOLBER_DATA_ATTACK}{PREFIX_NAME_DATA_ATTACK}{stats.TypeAttack}";

            AttackData = Resources.Load<AttackData>(pathAttackData);

            if (!AttackData)
            {
                throw new UnitException($"attack data unit {name} not found on path {pathAttackData}");
            }
        }

        #region Animations States
        public void EnterOnTriggerAnimationState(AnimationState type)
        {
            DisableAllParametersAnimator();

            animator.SetTrigger(type.ToString());
        }

        private void DisableAllParametersAnimator()
        {
            for (int i = 0; i < animator.parameters.Length; i++)
            {
               animator.SetBool(animator.parameters[i].name, false);
            }
        }

        public void SetAnimationState(AnimationState type)
        {
            if (type == currentAnimationState)
            {
                return;
            }
            DisableAllParametersAnimator();


            animator.SetBool(type.ToString(), true);
            currentAnimationState = type;
        }

        #endregion

        #region State System
        public virtual void InitStates()
        {

            statesMap = new Dictionary<Type, IState>();


            UnitStateIdle stateIdle = new UnitStateIdle();

            UnitStateDeath stateDeath = new UnitStateDeath();

            UnitStateAggressive stateAggressive = new UnitStateAggressive();

            AddState<UnitStateIdle>(stateIdle);
            AddState<UnitStateDeath>(stateDeath);
            AddState<UnitStateAggressive>(stateAggressive);

            SetStateByDefault();

        }

        protected void SetStateByDefault() => SetState(GetState<UnitStateIdle>());

        public virtual void SetStateAggresive(UnitBase target)
        {
            if (target == null)
            {
                throw new UnitException("target base unit argument is null");
            }


            if (target == this)
            {
                return;
            }

        }

        protected void SetStateDeath()
        {
            SetState(GetState<UnitStateDeath>());
        }

        protected void AddState<T>(IState state)
        {
            state.SetOwner(this);
            statesMap[typeof(T)] = state;
        }

        protected void SetState(IState state)
        {
            if (currentState != null)
            {

                currentState.Exit();
            }

            currentState = state;

            currentState.Enter();
        }

        protected IState GetState<T>() where T : IState
        {
            var type = typeof(T);
            return statesMap[type];
        }

        #endregion

        public virtual void SetPointMove(Vector3 point)
        {

            if (currentPoint == Vector3.negativeInfinity || currentPoint == Vector3.positiveInfinity)
            {
                throw new UnitException("point argument is infinity");
            }

            SetCurrentPoint(point);

        }

        private void SetCurrentPoint(Vector3 point)
        {
            currentPoint = point;
        }

        public void Hit(ulong hitValue, bool playHitAnim = true)
        {
            dynamicStats.currentHitPoints = (long)Mathf.Clamp(dynamicStats.currentHitPoints - (long)hitValue, 0, stats.StartHitPoints);


#if UNITY_EDITOR
            if (hitValue > 0)
            {
                Debug.Log($"{name} geted dps: Value: {hitValue} Current Value Hit Points: {dynamicStats.currentHitPoints}");
            }
#endif


            if (dynamicStats.currentHitPoints <= 0)
            {
                Death();
            }
        }

        public bool WatchingEnviroment (out UnitBase unitCasted)
        {
            unitCasted = null;
            RaycastHit hit;


#if UNITY_EDITOR
            Debug.DrawRay(transform.position, transform.forward, Color.blue);
#endif
            if (Physics.Raycast(transform.position, transform.forward, out hit)) {
                if (hit.collider.tag == TAG_UNIT)
                {
                    if (!hit.collider.TryGetComponent(out unitCasted)) 
                    {
                        
                        throw new UnitException($"GameObject {hit.collider.gameObject.name} not have component Unit Base");
                    }
#if UNITY_EDITOR
                    Debug.Log($"{name} catched unit {unitCasted.name}");
#endif
                    return true;
                }
            }

                return false;
            
            
        }

        public void Death()
        {
            SetStateDeath();
            onDeath?.Invoke();
            IsDead = true;
            collider.enabled = false;

            if (view.IsMine)
            {
                CallInvokingMethod(Remove, 5);
            }


            enabled = false;
        }

        public void RotateToPoint (Vector3 point)
        {
            Vector3 dir = point - transform.position;
            Quaternion root = Quaternion.LookRotation(dir);


            Quaternion result = Quaternion.Lerp(transform.rotation, root, 5 * Time.deltaTime);


            result.x = 0;
            result.z = 0;
            transform.rotation = result;
        }

        public void RotateToEnemy ()
        {
            if (!TargetEnemy)
            {
                return;
            }

            RotateToPoint(TargetEnemy.transform.position);
        }

        public void Damage()
        {
            if (TargetEnemy)
            {

                if (ProbabilityUtility.GenerateProbalityInt() > blundersUnitsSettings.ProcentProbalityBlunder)
                {
#if UNITY_EDITOR
                    Debug.Log($"{name} as blunder attack");
#endif

                    return;
                }
                ulong spreadHitValue = stats.Damage + (ulong)Random.Range(0, stats.DamageSpread + 1);

                ulong resultDamage = (ulong)TargetEnemy.AttackData.GetProcentDamageWithArmor((int)spreadHitValue, (int)TargetEnemy.stats.ArmorIndex, TargetEnemy.stats.TypeArmor);
                resultDamage = (ulong)TargetEnemy.ArmorData.GetProcentDamageWithAttack((int)resultDamage);
                TargetEnemy.Hit(resultDamage);
            }
        }

        public void Remove()
        {
            if (PhotonNetwork.IsConnected)
            {
            if (view.IsMine)
            {
                PhotonNetwork.Destroy(gameObject);
            }
            }


        }

        public void CallInvokingEveryMethod(Action method, float time)
        {
            InvokeRepeating(method.Method.Name, time, time);
        }

        public void CallInvokingMethod(Action method, float time)
        {
            Invoke(method.Method.Name, time);
        }
    }

}
