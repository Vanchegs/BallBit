using UnityEngine;

namespace Internal.Codebase.Infrastructure.Factories
{
    public interface IUIFactory
    {
        void UICreate(GameObject prefab, Transform spawnPosition);
    }
}