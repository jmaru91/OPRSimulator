using System;

namespace OPR
{
    public class UnitCanShootAfterAdvancedState : IUnitState
    {
        public event Action<UnitInput> OnStateChangeRequired;
        public UnitState State => UnitState.CanShootAfterAdvanced;

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