using System;

namespace OPR
{
    public class UnitResolveMeleeState : IUnitState
    {
        public event Action<UnitInput> OnStateChangeRequired;
        public UnitState State => UnitState.ResolveMelee;

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