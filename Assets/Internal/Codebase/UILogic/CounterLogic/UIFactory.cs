using UnityEngine;

namespace Internal.Codebase.UILogic.CounterLogic
{
    public class UIFactory : MonoBehaviour, IUIFactory
    {
        [SerializeField] private GameObject scorePrefab;
        
        public void UICreate(GameObject prefab, Transform spawnPosition) => 
            Instantiate(prefab, spawnPosition);
    }
}