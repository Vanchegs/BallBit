using TMPro;
using UnityEngine;
using Internal.Codebase.Common;

namespace Internal.Codebase.UILogic.StoreLogic
{
    public class StoreWallet : MonoBehaviour
    {
        public int WalletCount { get; set; }

        private TMP_Text walletText;

        private void Awake() => 
            walletText = GetComponent<TMP_Text>();
        
        private void OnEnable() => 
            GameEventBus.WalletChange += WalletCountChange;

        private void OnDisable() => 
            GameEventBus.WalletChange += WalletCountChange;

        private void WalletCountChange(int changeCount)
        {
            WalletCount = changeCount;
            walletText.text = $"{WalletCount}";
        }
    }
}
