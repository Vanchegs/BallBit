using System.Collections;
using System.Collections.Generic;
using Internal.Codebase.Saves;
using Internal.Codebase.UILogic.StoreLogic;
using UnityEngine;
using YG;

namespace Internal.Codebase.PurchaseLogic
{
    public class PurchaseHandler : MonoBehaviour
    {
        public static DataForSave SavesData;
        [field: SerializeField] public List<ShopItem> ShopItemsList { get; private set; } = new();

        private Dictionary<int, bool> ShopItems = new Dictionary<int, bool>();

        private void Start()
        {
            if (YandexGame.SDKEnabled)
            {
                ShopItems = YandexGame.savesData.dataForSave.ShopItemsForSave;
            }
            else
            {
                SavesData.ShopItemsForSave = new Dictionary<int, bool>
                {
                    { ShopItemsList[0].id , ShopItemsList[0].IsBuy },
                    { ShopItemsList[1].id , ShopItemsList[1].IsBuy },
                    { ShopItemsList[2].id , ShopItemsList[2].IsBuy },
                    { ShopItemsList[3].id , ShopItemsList[3].IsBuy },
                    { ShopItemsList[4].id , ShopItemsList[4].IsBuy },
                    { ShopItemsList[5].id , ShopItemsList[5].IsBuy },
                    { ShopItemsList[6].id , ShopItemsList[6].IsBuy },
                    { ShopItemsList[7].id , ShopItemsList[7].IsBuy },
                    { ShopItemsList[8].id , ShopItemsList[8].IsBuy },
                    { ShopItemsList[9].id , ShopItemsList[9].IsBuy },
                    { ShopItemsList[10].id , ShopItemsList[10].IsBuy },
                    { ShopItemsList[11].id , ShopItemsList[11].IsBuy }
                };

                SavesData.WalletCount = 0;
            }

            StartCoroutine(AutoSaver());
        }

        private IEnumerator AutoSaver()
        {
            while (true)
            {
                SavesData.ShopItemsForSave = new Dictionary<int, bool>
                {
                    { ShopItemsList[0].id , ShopItemsList[0].IsBuy },
                    { ShopItemsList[1].id , ShopItemsList[1].IsBuy },
                    { ShopItemsList[2].id , ShopItemsList[2].IsBuy },
                    { ShopItemsList[3].id , ShopItemsList[3].IsBuy },
                    { ShopItemsList[4].id , ShopItemsList[4].IsBuy },
                    { ShopItemsList[5].id , ShopItemsList[5].IsBuy },
                    { ShopItemsList[6].id , ShopItemsList[6].IsBuy },
                    { ShopItemsList[7].id , ShopItemsList[7].IsBuy },
                    { ShopItemsList[8].id , ShopItemsList[8].IsBuy },
                    { ShopItemsList[9].id , ShopItemsList[9].IsBuy },
                    { ShopItemsList[10].id , ShopItemsList[10].IsBuy },
                    { ShopItemsList[11].id , ShopItemsList[11].IsBuy }
                };
                
                yield return new WaitForSeconds(2);
            }
        }
    }
}
