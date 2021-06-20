using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UnitsSystem.StateSystem
{
    public class UnitStateMeleeAttack : UnitStateBase, IState
    {
        public void Enter()
        {

            targetInteraction.Agent.isStopped = true;
            targetInteraction.SetAnimationState(AnimationState.Idle);
            LogOfState("enter on state melee attack");
            SetStateExited(false);
        }

        public void Exit()
        {


            LogOfState("exit on state melee attack");
            SetStateExited(true);

        }

        public IEnumerator Update()
        {
            while (StateExited == false)
            {
                if (targetInteraction.TargetEnemy != null)
                {
                    yield return new WaitForSeconds(targetInteraction.Stats.SpeedAttack);
                    targetInteraction.SetAnimationState(AnimationState.Attack);
                    yield return new WaitForSeconds(targetInteraction.Stats.SpeedAttack / 2);
                    targetInteraction.SetAnimationState(AnimationState.Idle);
                }

                else
                {
                    yield return new WaitForSeconds(1.0f / 60.0f);
                }
            }

            yield return null;
        }
    }
}
