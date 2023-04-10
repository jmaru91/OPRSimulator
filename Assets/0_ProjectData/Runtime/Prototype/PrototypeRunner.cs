using Zenject;

namespace OPR
{
    public class PrototypeRunner : IInitializable
    {
        readonly Battlefield.Factory m_battlefieldFactory;
        Battlefield m_battlefield;

        public PrototypeRunner(Battlefield.Factory battlefieldFactory)
        {
            m_battlefieldFactory = battlefieldFactory;
        }

        public void Initialize()
        {
            m_battlefield = m_battlefieldFactory.Create();
        }
    }
}