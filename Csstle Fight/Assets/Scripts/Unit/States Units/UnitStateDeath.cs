
using System.Collections;
using UnityEngine;
namespace UnitsSystem.StateSystem
{
    public class UnitStateDeath : UnitStateBase, IState
    {
        public UnitStateDeath()
        {
        }

        public override void Enter()
        {
            base.Enter();
            targetInteraction.EnterOnTriggerAnimationState(AnimationState.Death);
            LogOfState("enter on state death");
        }

        public override void Exit()
        {
            base.Exit();
            LogOfState("exit on state death");
        }

        public override IEnumerator Update()
        {
            yield return null;
        }
    }

}
