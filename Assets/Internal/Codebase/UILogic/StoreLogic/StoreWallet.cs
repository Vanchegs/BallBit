using TMPro;
using UnityEngine;
using Internal.Codebase.Infrastructure;
using Internal.Codebase.Saves;
using YG;

namespace Internal.Codebase.UILogic.StoreLogic
{
    [RequireComponent(typeof(TMP_Text))]
    public class StoreWallet : MonoBehaviour
    {
        public static StoreWallet Wallet { get; private set; }

        private TMP_Text walletText;

        private void Awake()
        {
            Wallet = this;
            
            walletText = GetComponent<TMP_Text>();
            
            GameEventBus.OnLoaded += Load;
        }

        private void Start() => 
            UpdateUI();

        private void OnEnable()
        {
            GameEventBus.OnWalletChange += WalletCountChange;
            GameEventBus.OnWritingOffCount += WritingOffWalletCount;
            GameEventBus.UpdateCountUI += UpdateUI;
        }

        private void OnDisable()
        {
            GameEventBus.OnWalletChange -= WalletCountChange;
            GameEventBus.OnWritingOffCount -= WritingOffWalletCount;
            GameEventBus.UpdateCountUI -= UpdateUI;
        }

        private void OnDestroy()
        {
            GameEventBus.OnLoaded -= Load;
        }

        private void Load(DataForSave data) => 
            YandexGame.savesData.dataForSave.Currency = data.Currency;

        private void WalletCountChange(int changeCount)
        {
            YandexGame.savesData.dataForSave.Currency = changeCount;
            UpdateUI();
        }
        
        private void WritingOffWalletCount(int productPrice)
        {
            YandexGame.savesData.dataForSave.Currency -= productPrice;
            UpdateUI();
        }

        private void UpdateUI() => 
            walletText.text = $"{YandexGame.savesData.dataForSave.Currency}";
    }
}
