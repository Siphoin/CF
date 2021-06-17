

using UnityEngine;

public    class UnitStateBase
    {
    protected UnitBase targetInteraction;
    protected bool stateExited = false;

    public UnitStateBase ()
    {

    }


    protected void SetOwner (UnitBase target)
    {
        if (target == null)
        {
            throw new UnitStateException("target unit for state is null");
        }

        targetInteraction = target;
    }

    protected void LogOfState (string message)
    {
#if UNITY_EDITOR
        Debug.Log($"[Unit state message] unit {targetInteraction.name} {message}");
#endif
    }
}
