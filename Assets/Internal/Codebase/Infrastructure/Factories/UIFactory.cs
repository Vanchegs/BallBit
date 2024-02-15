using System;
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

        private void Awake() => 
            GameEventBus.OnLoaded += Load;

        private void Start()
        {
            shop = FindObjectOfType<Shop>(true);
        }

        private void Load(DataForSave data)
        {
            Debug.Log(uiListToSpawn[0] == null);
            Debug.Log(spawnPosition == null);
            Debug.Log(data == null);
            UICreate(uiListToSpawn[0], spawnPosition[0], data);
        }

        public void UICreate(GameObject prefab, Transform spawnPosition, DataForSave data)
        {
            shop = FindObjectOfType<Shop>(true);
            Debug.Log(shop == null);
            var i = Instantiate(prefab, spawnPosition);
            if (shop != null) 
                shop.Init(i, data);
            shop.UpdateUIFromSaves();
        }
    }
}