using UnityEngine;

namespace Internal.Codebase.Infrastructure.Factories
{
    public class UIFactory : MonoBehaviour, IUIFactory
    {
        [SerializeField] private GameObject uiPrefab;
        [SerializeField] private Transform spawnPosition;

        private void Start() =>
            UICreate(uiPrefab, spawnPosition);

        public void UICreate(GameObject prefab, Transform spawnPosition) =>
            Instantiate(prefab, spawnPosition);
    }
}