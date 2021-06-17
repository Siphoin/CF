
using System.Collections;
using UnityEngine;

public class UnitStateIdle : UnitStateBase, IState
    {
        public UnitStateIdle ()
        {

        }

    public void Enter()
    {
        LogOfState("enter on state idle");
        targetInteraction.SetAnimationState(AnimationState.Idle);
    }

    public void Exit()
    {
        LogOfState("exit on state idle");

        stateExited = true;
    }

    public IEnumerator Update()
    {
        throw new System.NotImplementedException();
    }


}