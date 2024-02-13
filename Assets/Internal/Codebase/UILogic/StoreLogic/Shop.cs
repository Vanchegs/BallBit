using System.Collections.Generic;
using System.Linq;
using Internal.Codebase.Saves;
using UnityEngine;

namespace Internal.Codebase.UILogic.StoreLogic
{
    public class Shop : MonoBehaviour
    {
        private List<ShopItem> shopItems= new();

        public void Init(GameObject canvas, DataForSave dataForSave)
        {
            Debug.Log(canvas == null);
            Debug.Log(dataForSave == null);
            Debug.Log(dataForSave.ItemsForSave == null);

            var shopView = FindObjectOfType<ShopView>();

            shopItems = new(shopView.shopItems);
            
            foreach (var item in shopItems)
            {
                item.shopSign.Button.onClick.AddListener(((() => Buy(item))));
            }
            
            InitShop(dataForSave.ItemsForSave);
        }

        private void Buy(ShopItem shopItem)
        {
            if (Saver.Self.SavesData.Currency >= shopItem.ProductPrice)
            {
                Saver.Self.SavesData.Currency -= shopItem.ProductPrice;
                Saver.Self.SavesData.ItemsForSave.First(x => x.Id == shopItem.Id).IsBuy = true;
                UpdateUI();
                Saver.Self.Save();
            }
        }

        public void InitShop(List<Item> items)
        {
            foreach (var shopItem in shopItems)
            {
                foreach (var item in items)
                {
                    if (item.Id == shopItem.Id)
                    {
                        if (item.IsBuy)
                        {
                            shopItem.shopSign.Button.gameObject.SetActive(false);
                            shopItem.shopSign.nameStoreSign.gameObject.SetActive(true);
                            shopItem.shopSign.descriptionStoreSign.gameObject.SetActive(true);
                            shopItem.shopSign.imageOfProduct.gameObject.SetActive(true);
                        }
                    }
                }
            }
        }

        private void UpdateUI()
        {
            foreach (var shopItem in shopItems)
            {
                foreach (var item in Saver.Self.SavesData.ItemsForSave)
                {
                    if (item.Id == shopItem.Id)
                    {
                        if (item.IsBuy)
                        {
                            shopItem.shopSign.Button.gameObject.SetActive(false);
                            shopItem.shopSign.nameStoreSign.gameObject.SetActive(true);
                            shopItem.shopSign.descriptionStoreSign.gameObject.SetActive(true);
                            shopItem.shopSign.imageOfProduct.gameObject.SetActive(true);
                        }
                    }
                }
            }
        }
    }
}