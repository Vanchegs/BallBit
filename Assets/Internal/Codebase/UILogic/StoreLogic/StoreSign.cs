using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Internal.Codebase.UILogic.StoreLogic
{
    public class StoreSign : MonoBehaviour
    {
        [field: SerializeField] public bool IsBuy { get; private set; }
        [field: SerializeField] public int ProductPrice { get; private set; }
        
        [SerializeField] private TMP_Text nameStoreSignText;
        [SerializeField] private TMP_Text descriptionStoreSignText;
        [SerializeField] private TMP_Text buyButtonText;
        
        [SerializeField] private Image imageStoreSign;

        [SerializeField] private Button buttonStoreSign;

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
            nameStoreSignText.gameObject.SetActive(false);
            descriptionStoreSignText.gameObject.SetActive(false);
            imageStoreSign.gameObject.SetActive(false);
        }
    }
}
