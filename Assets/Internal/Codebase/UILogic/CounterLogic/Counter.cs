using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using Internal.Codebase.BalloonLogic.Balloons;

namespace Internal.Codebase.UILogic.CounterLogic
{
    public class Counter : MonoBehaviour
    {
        public int Count { get; private set; }
        
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

        private void CountIncrease()
        {
            Count++;

            countText.text = $"{Count}";
        }

        private void CountRandomChange()
        {
            int changeNumber = Random.Range(-10, 10);

            Count += changeNumber;
            
            countText.text = $"{Count}";
        }
    }
}
    
