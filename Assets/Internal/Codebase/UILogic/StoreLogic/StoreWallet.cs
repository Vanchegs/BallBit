using TMPro;
using UnityEngine;
using Internal.Codebase.Infrastructure;

namespace Internal.Codebase.UILogic.StoreLogic
{
    public class StoreWallet : MonoBehaviour
    {
        public static StoreWallet Wallet { get; private set; }
        
        public int WalletCount { get; private set; }

        private TMP_Text walletText;

        private void Awake()
        {
            Wallet = this;
            
            walletText = GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            GameEventBus.OnWalletChange += WalletCountChange;
            GameEventBus.OnWritingOffCount += WritingOffWalletCount;
        }

        private void OnDisable()
        {
            GameEventBus.OnWalletChange -= WalletCountChange;
            GameEventBus.OnWritingOffCount -= WritingOffWalletCount;
        }

        private void WalletCountChange(int changeCount)
        {
            WalletCount = changeCount;
            walletText.text = $"{WalletCount}";
        }
        
        private void WritingOffWalletCount(int productPrice)
        {
            WalletCount -= productPrice;
            walletText.text = $"{WalletCount}";
        }
    }
}
