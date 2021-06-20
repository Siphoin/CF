
using System.Collections;
using UnityEngine;
namespace UnitsSystem.StateSystem
{
    public class UnitStateDeath : UnitStateBase, IState
    {
        public UnitStateDeath()
        {
        }

        public void Enter()
        {
            SetStateExited(false);
            targetInteraction.SetAnimationState(AnimationState.Death);
        }

        public void Exit()
        {
            LogOfState("exit on state death");

            SetStateExited(true);
        }

        public IEnumerator Update()
        {
            yield return null;
        }
    }

}
