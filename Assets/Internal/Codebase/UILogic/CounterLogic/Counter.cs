using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using Internal.Codebase.Common;

namespace Internal.Codebase.UILogic.CounterLogic
{
    public class Counter : MonoBehaviour
    {
        public int Count { get; private set; }
        
        private TMP_Text countText;

        private void Start()
        {
            countText = GetComponent<TMP_Text>();
            
            GameEventBus.WalletChange?.Invoke(Count);
        }

        private void OnEnable()
        {
            GameEventBus.SurpriseBalloonBit += CountRandomChange;
            GameEventBus.OrdinaryBalloonBit += CountIncrease;
        }

        private void OnDisable()
        {
            GameEventBus.SurpriseBalloonBit -= CountRandomChange;
            GameEventBus.OrdinaryBalloonBit -= CountIncrease;
        }

        private void CountIncrease()
        {
            Count++;

            countText.text = $"{Count}";
            
            GameEventBus.WalletChange?.Invoke(Count);
        }

        private void CountRandomChange()
        {
            int changeNumber = Random.Range(-10, 10);

            Count += changeNumber;
            
            countText.text = $"{Count}";
            
            GameEventBus.WalletChange?.Invoke(Count);
        }
    }
}
    
