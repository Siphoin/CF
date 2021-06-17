using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Unit.States_Units
{
    public class UnitStateMeleeAttack : UnitStateBase, IState
    {
        public void Enter()
        {
            LogOfState("enter on state melee attack");
        }

        public void Exit()
        {
            LogOfState("exit on state melee attack");
        }

        public IEnumerator Update()
        {
            while (stateExited == false)
            {
                if (targetInteraction.TargetEnemy != null) 
            }
        }
    }
}
