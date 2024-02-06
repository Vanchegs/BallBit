using System;
using TMPro;
using UnityEngine;

namespace Internal.Codebase.UILogic.StoreLogic
{
    public class StoreWallet : MonoBehaviour
    {
        public int WalletCount { get; private set; }

        private TMP_Text walletText;

        public static Action<int> WalletChange;

        private void OnEnable() => 
            WalletChange += WalletCountChange;

        private void OnDisable() => 
            WalletChange += WalletCountChange;

        private void Start() => 
            walletText = GetComponent<TMP_Text>();

        private void WalletCountChange(int changeCount)
        {
            WalletCount = changeCount;
            walletText.text = $"{WalletCount}";
        }
    }
}
