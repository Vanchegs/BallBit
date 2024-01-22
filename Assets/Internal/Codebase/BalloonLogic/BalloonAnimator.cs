using UnityEngine;

namespace Internal.Codebase.BalloonLogic
{
    public class BalloonAnimator : MonoBehaviour
    {
        private static readonly int IsClicked = Animator.StringToHash("IsClicked");
        
        private Balloon balloon;
        private Animator balloonAnimator;

        private void Start()
        {
            balloon = GetComponent<Balloon>();
            balloonAnimator = GetComponent<Animator>();
        }

        public void BalloonBitAnim() => balloonAnimator.SetTrigger(IsClicked);
    }
}