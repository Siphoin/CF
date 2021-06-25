using CoroutinesSystem;
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

        private Coroutine rotateCoroutine;
        public override void Enter()
        {
            base.Enter();
            targetInteraction.Agent.isStopped = true;
            targetInteraction.SetAnimationState(AnimationState.Idle);

            rotateCoroutine = Coroutines.StartRoutine(Rotating());


            LogOfState("enter on state melee attack");
        }

        public override void Exit()
        {
            base.Exit();


            if (rotateCoroutine != null)
            {
                Coroutines.StopRoutine(rotateCoroutine);
            }


            LogOfState("exit on state melee attack");

        }

        public override IEnumerator Update()
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

        private IEnumerator Rotating ()
        {
            while (StateExited == false)
            {

                yield return new WaitForSeconds(1.0f / 60.0f);


                targetInteraction.RotateToEnemy();

            }

            yield return null;
        }
    }
}
