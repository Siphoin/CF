using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace UnitsSystem.StateSystem
{
    public class UnitStateMeleeMove : UnitStateBase, IState
    {
        public void Enter()
        {
            targetInteraction.SetAnimationState(AnimationState.Run);
            targetInteraction.Agent.SetDestination(targetInteraction.CurrentPoint);

            SetStateExited(false);
            LogOfState("enter on state melee move");
        }

        public void Exit()
        {


            SetStateExited(true);
            LogOfState("exit on state melee move");
        }

        public IEnumerator Update()
        {
            yield return null;
        }
    }

}