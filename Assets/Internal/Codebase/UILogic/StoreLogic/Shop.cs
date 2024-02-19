using UnityEngine;
using Internal.Codebase.Saves;
using System.Collections.Generic;
using Internal.Codebase.Infrastructure;

namespace Internal.Codebase.UILogic.StoreLogic
{
    public class Shop : MonoBehaviour
    {
        private List<ShopItem> shopItems = new();

        public void Init(GameObject canvas, DataForSave dataForSave)
        {
            Debug.Log(canvas == null);
            Debug.Log(dataForSave == null);
            Debug.Log(dataForSave.ItemsForSave == null);

            var shopView = FindObjectOfType<ShopView>();

            shopItems = new(shopView.shopItems);

            foreach (var item in shopItems)
                item.shopSign.Button.onClick.AddListener(((() => Buy(item))));

            InitShop(dataForSave.ItemsForSave);
            UpdateUI();
        }

        private void Buy(ShopItem shopItem)
        {
            if (Saver.Self.SavesData.Currency >= shopItem.ProductPrice)
            {
                Saver.Self.SavesData.Currency -= shopItem.ProductPrice;
                Saver.Self.SavesData.ItemsForSave.ForEach(x =>
                {
                    if (x.Id == shopItem.Id)
                    {
                        x.IsBuy = true;
                        Debug.Log(x.IsBuy);
                    }
                });
                shopItem.shopSign.Button.gameObject.SetActive(false);
                GameEventBus.UpdateCountUI?.Invoke();
                Saver.Self.Save();
                UpdateUI();
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

        public void UpdateUI()
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
                            Debug.Log(item.IsBuy);
                        }
                        else
                        {
                            shopItem.shopSign.nameStoreSign.gameObject.SetActive(false);
                            shopItem.shopSign.descriptionStoreSign.gameObject.SetActive(false);
                            shopItem.shopSign.imageOfProduct.gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
    }
}