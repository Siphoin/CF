
using CoroutinesSystem;
using System.Collections;
using UnityEngine;
namespace UnitsSystem
{
    public class UnitStateBase : IState
    {
        protected UnitBase targetInteraction;

        protected Coroutine updateCorotine;
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

        public virtual void Enter()
        {
            SetStateExited(false);

            updateCorotine = Coroutines.StartRoutine(Update());
        }

        public virtual IEnumerator Update()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Exit()
        {
            SetStateExited(true);


            Coroutines.StopRoutine(updateCorotine);
        }
    }

}
