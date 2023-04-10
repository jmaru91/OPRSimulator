using UnityEngine;
using Zenject;

namespace OPR
{
    public class PrototypeInstaller : MonoInstaller
    {
        [SerializeField] GameObject m_battlefield;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PrototypeRunner>()
                     .AsSingle();

            Container.BindFactory<Battlefield, Battlefield.Factory>()
                     .FromSubContainerResolve()
                     .ByNewPrefabInstaller<BattlefieldInstaller>(m_battlefield)
                     .AsSingle();
        }
    }
}