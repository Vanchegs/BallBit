using System.Collections.Generic;
using Internal.Codebase.Saves;
using Internal.Codebase.UILogic.StoreLogic;
using UnityEngine;

namespace Internal.Codebase.Infrastructure.Factories
{
    public class UIFactory : MonoBehaviour, IUIFactory
    {
        [SerializeField] private List<GameObject> uiListToSpawn;
        [SerializeField] private List<Transform> spawnPosition;

        [SerializeField] private Shop shop;

        private void Start() => 
            GameEventBus.OnLoaded += Load;

        private void Load(DataForSave obj) => 
            UICreate(uiListToSpawn[0], spawnPosition[0], obj);

        public void UICreate(GameObject prefab, Transform spawnPosition, DataForSave data)
        {
            var i = Instantiate(prefab, spawnPosition);
            shop.Init(i, data);
        }
    }
}