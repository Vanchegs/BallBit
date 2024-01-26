using TMPro;
using UnityEngine;

namespace Internal.Codebase.UILogic.CounterLogic
{
    public class Counter : MonoBehaviour
    {
        [field: Min(0)] public int Count { get; private set; }
        
        private TMP_Text countText;

        private void Start() => countText = GetComponent<TMP_Text>();

        public void CountIncrease()
        {
            Count++;
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
            
            countText.text = $"{Count}";
        }
    }
}