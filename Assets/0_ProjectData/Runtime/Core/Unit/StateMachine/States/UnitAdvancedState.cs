using System;

namespace OPR
{
    public class UnitAdvancedState : IUnitState
    {
        public event Action<UnitInput> OnStateChangeRequired;
        public UnitState State => UnitState.Advanced;

        public void OnStateEnter()
        {
            throw new NotImplementedException();
        }

        public void OnStateExit()
        {
            throw new NotImplementedException();
        }
    }
}