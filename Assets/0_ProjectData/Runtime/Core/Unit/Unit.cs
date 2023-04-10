using System.Collections.Generic;

namespace OPR
{
    public class Unit
    {
        readonly UnitStats m_stats;
        readonly UnitStateMachine m_unitStateMachine;
        readonly IReadOnlyList<Model> m_models;

        public Player Owner { get; }
        public UnitState State => m_unitStateMachine.State;

        public Unit(UnitStats unitStats, Player owner, ModelsManager modelsManager, UnitStateMachine unitStateMachine)
        {
            Owner = owner;

            m_stats = unitStats;
            m_unitStateMachine = unitStateMachine;
            m_models = modelsManager.CreateModels(unitStats);
        }

        public void UpdateState(UnitInput input)
        {
            m_unitStateMachine.UpdateState(input);
        }
    }
}