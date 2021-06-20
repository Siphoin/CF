
using UnityEngine;
namespace UnitsSystem
{
    public class UnitStateBase
    {
        protected UnitBase targetInteraction;
        public bool StateExited { get; private set; } = false;

        public UnitStateBase()
        {

        }


        public void SetOwner(UnitBase target)
        {
            if (target == null)
            {
                throw new UnitStateException("target unit for state is null");
            }

            targetInteraction = target;
        }

        protected void LogOfState(string message)
        {
#if UNITY_EDITOR
            Debug.Log($"[Unit state message] unit {targetInteraction.name} {message}");
#endif
        }

        protected void SetStateExited(bool status)
        {
            StateExited = status;
        }
    }

}
