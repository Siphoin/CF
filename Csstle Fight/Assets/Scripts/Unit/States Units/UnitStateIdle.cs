
using System.Collections;
using UnityEngine;
namespace UnitsSystem.StateSystem
{
    public class UnitStateIdle : UnitStateBase, IState
    {
        public UnitStateIdle()
        {

        }

        public override void Enter()
        {
            base.Enter();
            targetInteraction.SetAnimationState(AnimationState.Idle);
            LogOfState("enter on state idle");
        }

        public override void Exit()
        {
            base.Exit();
            LogOfState("exit on state idle");

        }

        public override IEnumerator Update()
        {
            yield return null;
        }


    }

}