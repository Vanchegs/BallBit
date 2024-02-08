using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Internal.Codebase.UILogic.StoreLogic
{
    public class ShopSign : MonoBehaviour
    {
        private ShopItem shopItem;
        
        [SerializeField] private TMP_Text nameStoreSign;
        [SerializeField] private TMP_Text descriptionStoreSign;
        [SerializeField] private TMP_Text buyButtonText;
        
        [SerializeField] private Image imageOfProduct;

        private void Start()
        {
            shopItem = GetComponent<ShopItem>();
            
            CheckIsBuy();

            SettingPrice();
        }

        private void SettingPrice() => 
            buyButtonText.text = $"{shopItem.ProductPrice}";

        public void CheckIsBuy()
        {
            if (!shopItem.IsBuy)
            {
                nameStoreSign.gameObject.SetActive(false);
                descriptionStoreSign.gameObject.SetActive(false);
                imageOfProduct.gameObject.SetActive(false);
            }
            else
            {
                nameStoreSign.gameObject.SetActive(true);
                descriptionStoreSign.gameObject.SetActive(true);
                imageOfProduct.gameObject.SetActive(true);
            }
        }
    }
}
