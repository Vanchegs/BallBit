using Internal.Codebase.UILogic.CounterLogic;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Infrastructure
{
    public class PrefabInstaller : MonoInstaller
    {
        [SerializeField] private Counter counterPrefab;

        public override void InstallBindings() => 
            Container.Bind<Counter>().FromInstance(counterPrefab).AsSingle();
    }
}
