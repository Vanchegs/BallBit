using System;
using TMPro;
using UnityEngine;
using Internal.Codebase.Infrastructure;
using Internal.Codebase.Saves;

namespace Internal.Codebase.UILogic.StoreLogic
{
    [RequireComponent(typeof(TMP_Text))]
    public class StoreWallet : MonoBehaviour
    {
        public static StoreWallet Wallet { get; private set; }
        
        public int WalletCount { get; private set; }

        private TMP_Text walletText;

        private void Awake()
        {
            Wallet = this;
            
            walletText = GetComponent<TMP_Text>();
            
            GameEventBus.OnLoaded += Load;
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

        private void OnDestroy()
        {
            GameEventBus.OnLoaded -= Load;
        }

        private void Load(DataForSave data) => 
            WalletCount = data.Currency;

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
