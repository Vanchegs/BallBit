using System;
using Internal.Codebase.Common;
using TMPro;
using UnityEngine;

namespace Internal.Codebase.UILogic.StoreLogic
{
    public class StoreWallet : MonoBehaviour
    {
        private int WalletCount { get; set; }

        private TMP_Text walletText;

        private void OnEnable() => 
            GameEventBus.WalletChange += WalletCountChange;

        private void OnDisable() => 
            GameEventBus.WalletChange += WalletCountChange;

        private void Start() => 
            walletText = GetComponent<TMP_Text>();

        private void WalletCountChange(int changeCount)
        {
            WalletCount = changeCount;
            walletText.text = $"{WalletCount}";
        }
    }
}
