
using System.Collections;
using UnityEngine;

public  class UnitStateDeath : UnitStateBase, IState
    {
    public UnitStateDeath ()
    {

    }

    public void Enter()
    {
        targetInteraction.SetAnimationState(AnimationState.Death);
    }

    public void Exit()
    {
        LogOfState("exit on state death");

        stateExited = true;
    }

    public IEnumerator Update()
    {
        throw new System.NotImplementedException();
    }
}
