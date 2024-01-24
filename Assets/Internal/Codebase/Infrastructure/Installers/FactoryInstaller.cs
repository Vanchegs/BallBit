using Internal.Codebase.BalloonLogic;
using Zenject;

namespace Internal.Codebase.Infrastructure.Installers
{
    public class FactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IBalloonFactory>().To<BalloonFactory>().FromNew().AsSingle();
        }
    }
}