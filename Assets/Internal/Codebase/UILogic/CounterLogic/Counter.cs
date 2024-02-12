using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using Internal.Codebase.Infrastructure;
using Internal.Codebase.Saves;

namespace Internal.Codebase.UILogic.CounterLogic
{
    [RequireComponent(typeof(TMP_Text))]
    public class Counter : MonoBehaviour
    {
        public int Count { get; private set; }
        
        private TMP_Text countText;

        private void Start() =>
            countText = GetComponent<TMP_Text>();

        private void OnEnable()
        {
            GameEventBus.OnSurpriseBalloonBit += CountRandomChange;
            GameEventBus.OnOrdinaryBalloonBit += CountIncrease;
            GameEventBus.OnWritingOffCount += WritingOffCount;
            GameEventBus.OnLoaded += Load;
        }

        private void OnDisable()
        {
            GameEventBus.OnSurpriseBalloonBit -= CountRandomChange;
            GameEventBus.OnOrdinaryBalloonBit -= CountIncrease;
            GameEventBus.OnWritingOffCount -= WritingOffCount;
            GameEventBus.OnLoaded -= Load;
        }

        private void Load(DataForSave data) => 
            Count = data.Currency;

        private void CountIncrease()
        {
            Count++;
            
            countText.text = $"{Count}";
            
            GameEventBus.OnWalletChange?.Invoke(Count);

            Saver.Self.SavesData.Currency = Count;
            Saver.Self.Save();
        }

        private void CountRandomChange()
        {
            var changeNumber = Random.Range(-10, 10);
            
            Count += changeNumber;
            
            if (Count < 0) Count = 0;
            countText.text = $"{Count}";
            
            GameEventBus.OnWalletChange?.Invoke(Count);
            
            Saver.Self.SavesData.Currency = Count;
            Saver.Self.Save();
        }
        
        private void WritingOffCount(int productPrice)
        {
            Count -= productPrice;
            countText.text = $"{Count}";
        }
    }
}
    
