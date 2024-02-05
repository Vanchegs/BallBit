using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using Internal.Codebase.BalloonLogic.Balloons;

namespace Internal.Codebase.UILogic.CounterLogic
{
    public class Counter : MonoBehaviour
    {
        [field: Min(0)] public int Count { get; private set; }
        
        private TMP_Text countText;

        private void Start() => 
            countText = GetComponent<TMP_Text>();

        private void OnEnable()
        {
            Balloon.SurpriseBalloonBit += CountRandomChange;
            Balloon.OrdinaryBalloonBit += CountIncrease;
        }

        private void OnDisable()
        {
            Balloon.SurpriseBalloonBit -= CountRandomChange;
            Balloon.OrdinaryBalloonBit -= CountIncrease;
        }

        public void CountIncrease()
        {
            Count++;
            
            StoreWallet.StoreWallet.WalletChange?.Invoke(Count);
            
            countText.text = $"{Count}";
        }

        public void CountRandomChange()
        {
            var randomValueChange = Random.Range(-10, 10);
            
            Debug.Log(randomValueChange);
            
            Count += randomValueChange;

            if (Count < 0)
                Count = 0;
            
            Debug.Log(Count);
            
            StoreWallet.StoreWallet.WalletChange?.Invoke(Count);
            
            countText.text = $"{Count}";
        }
    }
}