using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Infrastructure.Factories
{
    public class UIFactory : MonoBehaviour, IUIFactory
    {
        [SerializeField] private List<GameObject> uiListToSpawn; 
        [SerializeField] private List<Transform> spawnPosition;

        private void Start()
        {
            UICreate(uiListToSpawn[0], spawnPosition[0]);
            UICreate(uiListToSpawn[1], spawnPosition[1]);
        }

        public void UICreate(GameObject prefab, Transform spawnPosition) =>
            Instantiate(prefab, spawnPosition);

        public void ZanjectUICreate(GameObject prefab, Transform spawnPosition)
        {
            
        }
    }
}