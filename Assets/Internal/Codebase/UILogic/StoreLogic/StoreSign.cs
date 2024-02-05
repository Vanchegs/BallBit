using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Internal.Codebase.UILogic.StoreLogic
{
    public class StoreSign : MonoBehaviour
    {
        [field: SerializeField] public bool IsBuy { get; private set; }
        
        [SerializeField] private TMP_Text nameStoreSign;
        [SerializeField] private TMP_Text descriptionStoreSign;
        
        [SerializeField] private Image imageStoreSign;

        [SerializeField] private Button buttonStoreSign;

        private void Start()
        {
            CheckIsBuy();
        }

        private void CheckIsBuy()
        {
            if (IsBuy) return;
            nameStoreSign.gameObject.SetActive(false);
            descriptionStoreSign.gameObject.SetActive(false);
            imageStoreSign.gameObject.SetActive(false);
        }
    }
}
