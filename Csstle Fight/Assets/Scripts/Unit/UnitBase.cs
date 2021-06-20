using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnitsSystem.StateSystem;
using UnityEngine;
using UnityEngine.AI;
namespace UnitsSystem
{


    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(PhotonTransformView))]
    public class UnitBase : TeamObject, IPunObservable, IAnimationStateController
    {
        protected AnimationState currentAnimationState;

        private IState currentState;

        private Vector3 currentPoint;

        private NavMeshAgent agent;

        protected Animator animator;

        private Dictionary<Type, IState> statesMap;


        [Header("Данные о юните")]
        [SerializeField] private StatsUnit stats;

        public UnitBase TargetEnemy { get; protected set; }
        public StatsUnit Stats { get => stats; }
        public IState CurrentState { get => currentState; }
        public Vector3 CurrentPoint { get => currentPoint; }
        public NavMeshAgent Agent { get => agent; }
        protected Dictionary<Type, IState> StatesMap { get => statesMap; }



        // Start is called before the first frame update
        void Start()
        {
        }


        protected void InitUnit()
        {
            InitStates();
            IniTeamObject();


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


        }

        // Update is called once per frame
        void Update()
        {

        }
        #region Animations States
        public void EnterOnTriggerAnimationState(AnimationState type)
        {
            for (int i = 0; i < animator.runtimeAnimatorController.animationClips.Length; i++)
            {
                animator.SetBool(animator.runtimeAnimatorController.animationClips[i].name, false);
            }

            animator.SetTrigger(type.ToString());
        }

        public void SetAnimationState(AnimationState type)
        {
            if (type != currentAnimationState)
            {
                for (int i = 0; i < animator.runtimeAnimatorController.animationClips.Length; i++)
                {
                    animator.SetBool(animator.runtimeAnimatorController.animationClips[i].name, false);
                    Debug.Log(animator.runtimeAnimatorController.animationClips[i].name);
                }
                animator.SetBool(type.ToString(), true);
                currentAnimationState = type;
            }
        }

        #endregion

        #region State System
        public virtual void InitStates()
        {

            statesMap = new Dictionary<Type, IState>();
            UnitStateIdle stateIdle = new UnitStateIdle();

            UnitStateDeath stateDeath = new UnitStateDeath();

            AddState<UnitStateIdle>(stateIdle);
            AddState<UnitStateDeath>(stateDeath);


            SetStateByDefault();

        }

        protected void SetStateByDefault()
        {
            SetState(GetState<UnitStateIdle>());
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
                StopCoroutine(currentState.Update());
            }

            currentState = state;

            currentState.Enter();

            StartCoroutine(currentState.Update());
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


            currentPoint = point;

        }

    }

}
