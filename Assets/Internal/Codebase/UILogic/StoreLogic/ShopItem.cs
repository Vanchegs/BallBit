using UnityEngine;

namespace Internal.Codebase.UILogic.StoreLogic
{
    public class ShopItem : MonoBehaviour
    {
        [field: SerializeField] public bool IsBuy { get; private set; }
        
        [field: SerializeField] public int ProductPrice { get; private set; }
    }
}
