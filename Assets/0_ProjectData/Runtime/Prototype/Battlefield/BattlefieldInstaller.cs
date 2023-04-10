using UnityEngine;
using Zenject;

namespace OPR
{
    public class BattlefieldInstaller : Installer<BattlefieldInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<Rect>()
                     .AsSingle();
            
            Container.Bind<DebugRectDrawer>()
                     .FromComponentOnRoot()
                     .AsSingle();
            
            Container.Bind<Transform>()
                     .FromComponentOnRoot()
                     .AsSingle();
            
            Container.BindInterfacesAndSelfTo<Battlefield>()
                     .AsSingle();
        }
    }
}