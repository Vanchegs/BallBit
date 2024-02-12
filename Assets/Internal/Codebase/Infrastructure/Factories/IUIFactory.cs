using Internal.Codebase.Saves;
using UnityEngine;

namespace Internal.Codebase.Infrastructure.Factories
{
    public interface IUIFactory
    {
        void UICreate(GameObject prefab, Transform spawnPosition, DataForSave data);
    }
}