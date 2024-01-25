using TMPro;
using UnityEngine;

namespace Internal.Codebase.CounterLogic
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
            
            if(Count - randomValueChange >= 0)
                Count--;
            else
                Count = 0;

            countText.text = $"{Count}";
        }
    }
}