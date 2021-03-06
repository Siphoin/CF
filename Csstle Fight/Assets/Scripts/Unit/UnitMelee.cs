using System;
using UnitsSystem.StateSystem;
using UnityEngine;

namespace UnitsSystem
{
    public class UnitMelee : UnitBase
    {

        // Use this for initialization
        void Start()
        {
            InitUnit();
        }


        public override void SetPointMove(Vector3 point)
        {
            base.SetPointMove(point);

            SetState(GetState<UnitStateMeleeMove>());


        }

        public override void InitStates()
        {
            base.InitStates();

            UnitStateMeleeAttack stateAttack = new UnitStateMeleeAttack();
            UnitStateMeleeMove stateMove = new UnitStateMeleeMove();

            AddState<UnitStateMeleeMove>(stateMove);
            AddState<UnitStateMeleeAttack>(stateAttack);
            
        }
        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == TAG_UNIT)
            {
                UnitBase unit = GetUnitWithCollision(collision);


                if (TargetEnemy == null)
                {
                    AttackUnit(unit);
                }

                else if (TargetEnemy == unit)
                {
                    AttackUnit(unit);
                }

            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == TAG_UNIT)
            {
                if (TargetEnemy != null && TargetEnemy == GetUnitWithCollision(collision))
                {
                    if (CurrentState == StatesMap[typeof(UnitStateMeleeAttack)])
                    {
                        TargetEnemy.onDeath -= EnemyOfDeath;


                        if (!TargetEnemy.IsDead)
                        {
                            SetStateAggresive(TargetEnemy);
                        }

                       else
                        {
                            SetStateByDefault();
                        }
                    }
                }

            }

        }

        private void EnemyOfDeath()
        {
            SetStateByDefault();
            TargetEnemy.onDeath -= EnemyOfDeath;
        }

        private UnitBase GetUnitWithCollision (Collision collision)
        {
            UnitBase unit = null;

            if (!collision.gameObject.TryGetComponent(out unit))
            {
                throw new UnitException($"collision object ({collision.gameObject.name}) not have component Unit Base");
            }

            return unit;
        }

        public void AttackUnit (UnitBase target)
        {
            if (target == null)
            {
                throw new UnitException("target base unit argument is null");
            }

            TargetEnemy = target;
            SetState(GetState<UnitStateMeleeAttack>());
            TargetEnemy.onDeath += EnemyOfDeath;
        }

        public override void SetStateAggresive(UnitBase target)
        {
            base.SetStateAggresive(target);


            TargetEnemy = target;
            SetState(GetState<UnitStateAggressive>());
            TargetEnemy.onDeath += EnemyOfDeath;

        }

    }
}