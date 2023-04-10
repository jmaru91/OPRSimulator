using System;

namespace OPR
{
    public class UnitStateMachine : IDisposable
    {
        readonly UnitStates m_unitStates;
        IUnitState m_currentState;

        public UnitState State => m_currentState.State;
        
        public UnitStateMachine(UnitStates unitStates)
        {
            m_unitStates = unitStates;

            m_currentState = m_unitStates.StartingState;
            m_currentState.OnStateChangeRequired += UpdateState;
        }

        public void Dispose()
        {
            m_currentState.OnStateChangeRequired -= UpdateState;
        }

        public void UpdateState(UnitInput input)
        {
            if (!UnitStateMachineConnections.TryProcessInput(m_currentState.State, input, out UnitState newState))
            {
                // TODO exception
            }

            if (!m_unitStates.TryGetConcreteState(newState, out IUnitState newConcreteState))
            {
                // TODO exception
            }

            m_currentState.OnStateChangeRequired -= UpdateState;
            m_currentState.OnStateExit();

            m_currentState = newConcreteState;
            m_currentState.OnStateChangeRequired += UpdateState;
            m_currentState.OnStateEnter();
        }
    }
}