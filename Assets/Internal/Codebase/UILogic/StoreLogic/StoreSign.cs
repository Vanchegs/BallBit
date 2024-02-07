using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Internal.Codebase.UILogic.StoreLogic
{
    public class StoreSign : MonoBehaviour
    {
        [field: SerializeField] public bool IsBuy { get; private set; }
        [field: SerializeField] public int ProductPrice { get; private set; }
        
        [SerializeField] private TMP_Text nameStoreSign;
        [SerializeField] private TMP_Text descriptionStoreSign;
        [SerializeField] private TMP_Text buyButtonText;
        
        [SerializeField] private Image imageOfProduct;

        [SerializeField] private Button buyButton;

        private void Start()
        {
            CheckIsBuy();

            SettingPrice();
        }

        private void SettingPrice() => 
            buyButtonText.text = $"{ProductPrice}";

        private void CheckIsBuy()
        {
            if (IsBuy) return;
            nameStoreSign.gameObject.SetActive(false);
            descriptionStoreSign.gameObject.SetActive(false);
            imageOfProduct.gameObject.SetActive(false);
        }
    }
}
