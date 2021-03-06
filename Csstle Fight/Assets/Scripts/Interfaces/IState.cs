using System.Collections;
using System.Collections.Generic;
using UnitsSystem;

public   interface IState
    {
    /// <summary>
    /// Enter on state
    /// </summary>
    void Enter();
    /// <summary>
    /// Update state
    /// </summary>
    IEnumerator Update();
    /// <summary>
    /// Exit on current state
    /// </summary>
    void Exit();

    void SetOwner(UnitBase target);
    }
