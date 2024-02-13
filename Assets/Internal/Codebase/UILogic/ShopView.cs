using System.Collections.Generic;
using Internal.Codebase.UILogic.StoreLogic;
using UnityEngine;

namespace Internal.Codebase.UILogic
{
    public class ShopView : MonoBehaviour
    {
        [field: SerializeField] public List<ShopItem> shopItems;
    }
}
