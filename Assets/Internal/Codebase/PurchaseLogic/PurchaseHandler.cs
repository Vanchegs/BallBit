using System.Collections.Generic;
using Internal.Codebase.UILogic.StoreLogic;
using UnityEngine;

namespace Internal.Codebase.PurchaseLogic
{
    public class PurchaseHandler : MonoBehaviour
    {
        [field: SerializeField] public List<ShopSign> ShopItems { get; private set; }
    }
}
