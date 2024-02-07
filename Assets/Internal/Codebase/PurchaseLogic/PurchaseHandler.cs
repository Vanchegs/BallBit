using System;
using System.Collections.Generic;
using Internal.Codebase.UILogic.StoreLogic;
using UnityEngine;

namespace Internal.Codebase.PurchaseLogic
{
    public class PurchaseHandler : MonoBehaviour
    {
        [field: SerializeField] public List<GameObject> NameShopItems { get; private set; } = new();
        [field: SerializeField] public List<ShopItem> ShopItems { get; private set; } = new();

        private Dictionary<string, bool> shopItemsForSave;

        private void Start()
        {
            shopItemsForSave = new Dictionary<string, bool>()
            {
                { NameShopItems[0].name, ShopItems[0].IsBuy },
                { NameShopItems[1].name, ShopItems[1].IsBuy },
                { NameShopItems[2].name, ShopItems[2].IsBuy },
                { NameShopItems[3].name, ShopItems[3].IsBuy },
                { NameShopItems[4].name, ShopItems[4].IsBuy },
                { NameShopItems[5].name, ShopItems[5].IsBuy },
                { NameShopItems[6].name, ShopItems[6].IsBuy },
                { NameShopItems[7].name, ShopItems[7].IsBuy },
                { NameShopItems[8].name, ShopItems[8].IsBuy },
                { NameShopItems[9].name, ShopItems[9].IsBuy },
                { NameShopItems[10].name, ShopItems[10].IsBuy },
                { NameShopItems[11].name, ShopItems[11].IsBuy },
            };
        }
    }
}
