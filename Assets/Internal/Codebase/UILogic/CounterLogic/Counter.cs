using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using Internal.Codebase.Infrastructure;
using Internal.Codebase.PurchaseLogic;
using YG;

namespace Internal.Codebase.UILogic.CounterLogic
{
    public class Counter : MonoBehaviour
    {
        public int Count { get; private set; }
        
        private TMP_Text countText;

        private void Start()
        {
            if (YandexGame.SDKEnabled) 
                Count = YandexGame.savesData.dataForSave.WalletCount;

            countText = GetComponent<TMP_Text>();
            
            GameEventBus.OnWalletChange?.Invoke(Count);
        }

        private void OnEnable()
        {
            GameEventBus.OnSurpriseBalloonBit += CountRandomChange;
            GameEventBus.OnOrdinaryBalloonBit += CountIncrease;
            GameEventBus.OnWritingOffCount += WritingOffCount;
        }

        private void OnDisable()
        {
            GameEventBus.OnSurpriseBalloonBit -= CountRandomChange;
            GameEventBus.OnOrdinaryBalloonBit -= CountIncrease;
            GameEventBus.OnWritingOffCount -= WritingOffCount;
        }

        private void CountIncrease()
        {
            Count++;
            
            countText.text = $"{Count}";
            
            GameEventBus.OnWalletChange?.Invoke(Count);

            PurchaseHandler.SavesData.WalletCount = Count;
        }

        private void CountRandomChange()
        {
            var changeNumber = Random.Range(-10, 10);
            
            Count += changeNumber;
            
            if (Count < 0) Count = 0;
            countText.text = $"{Count}";
            
            GameEventBus.OnWalletChange?.Invoke(Count);
            
            PurchaseHandler.SavesData.WalletCount = Count;
        }
        
        private void WritingOffCount(int productPrice)
        {
            Count -= productPrice;
            countText.text = $"{Count}";
        }
    }
}
    
