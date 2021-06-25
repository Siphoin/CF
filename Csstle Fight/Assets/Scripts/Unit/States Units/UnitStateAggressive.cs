using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsSystem;
using UnityEngine;

namespace UnitsSystem.StateSystem
{
    class UnitStateAggressive : UnitStateBase, IState
    {
        public override void Enter()
        {
            base.Enter();
            LogOfState("enter on state aggresive");
            targetInteraction.SetAnimationState(AnimationState.Run);
        }

        public override void Exit()
        {
            base.Exit();
            LogOfState("exit on state aggresive");
        }

        public override IEnumerator Update()
        {
            while (true)
            {
                yield return new WaitForSeconds(1.0f / 60.0f);

                if (targetInteraction.TargetEnemy)
                {
                targetInteraction.Agent.SetDestination(targetInteraction.TargetEnemy.transform.position);
                }

            }
        }
    }
}
