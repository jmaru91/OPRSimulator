using System;

namespace OPR
{
    public interface IUnitState
    {
        event Action<UnitInput> OnStateChangeRequired;
        UnitState State { get; }
        
        void OnStateEnter();
        void OnStateExit();
    }
}