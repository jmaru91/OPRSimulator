using System;
using System.Collections.Generic;
using System.Linq;

namespace OPR
{
    public class UnitStates
    {
        readonly Dictionary<UnitState, IUnitState> m_states;

        public IUnitState StartingState { get; }

        public UnitStates(IEnumerable<IUnitState> allStates)
        {
            m_states = allStates.ToDictionary(s => s.State, s => s);
            StartingState = m_states[UnitState.Idle];
        }

        public bool TryGetConcreteState(UnitState stateType, out IUnitState state)
        {
            return m_states.TryGetValue(stateType, out state);
        }
    }
}