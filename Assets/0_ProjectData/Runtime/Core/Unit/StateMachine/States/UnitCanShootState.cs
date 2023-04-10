using System;

namespace OPR
{
    public class UnitCanShootState : IUnitState
    {
        public event Action<UnitInput> OnStateChangeRequired;
        public UnitState State => UnitState.CanShoot;

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