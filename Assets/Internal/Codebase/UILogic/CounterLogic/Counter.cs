using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using Internal.Codebase.Infrastructure;

namespace Internal.Codebase.UILogic.CounterLogic
{
    public class Counter : MonoBehaviour
    {
        public int Count { get; private set; }
        
        private TMP_Text countText;

        private void Start()
        {
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
            
            GameEventBus.OnWalletChange?.Invoke(Count);
            
            countText.text = $"{Count}";
        }

        private void CountRandomChange()
        {
            int changeNumber = Random.Range(-10, 10);
            
            Count += changeNumber;
            
            if (Count < 0) Count = 0;
            countText.text = $"{Count}";
            
            GameEventBus.OnWalletChange?.Invoke(Count);
        }
        
        private void WritingOffCount(int productPrice)
        {
            Count -= productPrice;
            countText.text = $"{Count}";
        }
    }
}
    
