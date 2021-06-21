
using System.Collections;
using UnityEngine;
namespace UnitsSystem.StateSystem
{
    public class UnitStateIdle : UnitStateBase, IState
    {
        public UnitStateIdle()
        {

        }

        public void Enter()
        {
            targetInteraction.SetAnimationState(AnimationState.Idle);
            LogOfState("enter on state idle");
            SetStateExited(false);
        }

        public void Exit()
        {
            LogOfState("exit on state idle");
            SetStateExited(true);

        }

        public IEnumerator Update()
        {
            yield return null;
        }


    }

}