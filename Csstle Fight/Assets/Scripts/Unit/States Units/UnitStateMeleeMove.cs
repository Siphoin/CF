using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UnitsSystem.StateSystem
{
    public class UnitStateMeleeMove : UnitStateBase, IState
    {
        public override void Enter()
        {
            base.Enter();


            targetInteraction.SetAnimationState(AnimationState.Run);
            targetInteraction.Agent.SetDestination(targetInteraction.CurrentPoint);
            LogOfState("enter on state melee move");
        }

        public override void Exit()
        {
            base.Exit();
            LogOfState("exit on state melee move");
        }

        public override IEnumerator Update()
        {
            while (true)
            {
                yield return new WaitForSeconds(1.0f / 60.0f);



                UnitBase castedUnit = null;



                if (targetInteraction.WatchingEnviroment(out castedUnit))
                {
                    targetInteraction.SetStateAggresive(castedUnit);
                }
            }
        }
    }

}