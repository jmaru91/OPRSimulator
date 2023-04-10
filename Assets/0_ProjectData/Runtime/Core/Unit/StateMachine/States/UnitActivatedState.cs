using System;

namespace OPR
{
    public class UnitActivatedState : IUnitState
    {
        public event Action<UnitInput> OnStateChangeRequired;
        public UnitState State => UnitState.Activated;

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