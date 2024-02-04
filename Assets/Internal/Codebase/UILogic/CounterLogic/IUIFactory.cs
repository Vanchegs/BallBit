using UnityEngine;

namespace Internal.Codebase.UILogic.CounterLogic
{
    public interface IUIFactory
    {
        void UICreate(GameObject prefab, Transform spawnPosition);
    }
}