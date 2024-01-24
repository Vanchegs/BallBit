using Internal.Codebase.BalloonLogic.BalloonsConfigs;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Infrastructure.Installers
{
    public class ConfigInstallers : MonoInstaller
    {
        [SerializeField] private BalloonsConfig BalloonsConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<BalloonsConfig>().FromInstance(BalloonsConfig).AsSingle();
        }
    }
}