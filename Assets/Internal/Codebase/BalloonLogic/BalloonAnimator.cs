using Internal.Codebase.BalloonLogic.BalloonBitLogic;
using UnityEngine;

namespace Internal.Codebase.BalloonLogic
{
    public class BalloonAnimator : MonoBehaviour
    {
        private static readonly int IsClicked = Animator.StringToHash("IsClicked");
        
        private Animator balloonAnimator;
        private ClickDetection clickDetector;

        private void Start()
        {
            balloonAnimator = GetComponent<Animator>();
            clickDetector = GetComponent<ClickDetection>();
            
            clickDetector.onClick.AddListener(BalloonBitAnim);
        }

        public void BalloonBitAnim() => balloonAnimator.SetTrigger(IsClicked);
    }
}