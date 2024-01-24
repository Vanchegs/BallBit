using Internal.Codebase.BalloonLogic.BalloonsConfigs;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Infrastructure.Installers
{
    public class ConfigInstallers : MonoInstaller
    {
        [SerializeField] private BalloonConfig normalBalloonConfig;
        [SerializeField] private BalloonConfig bangBalloonConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<BalloonConfig>().FromInstance(normalBalloonConfig).AsSingle();
            Container.Bind<BalloonConfig>().FromInstance(bangBalloonConfig).AsSingle();
        }
    }
}