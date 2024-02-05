using Internal.Codebase.BalloonLogic.BalloonCreateLogic;
using UnityEngine;

namespace Internal.Codebase.BalloonLogic.Balloons
{
    public class SurpriseBalloon : Balloon
    {
        private void Start()
        {
            ConstantSpeed = 0.08f;
            
            BalloonTransform = GetComponent<Transform>();
            
            RandomizationStartPosition();
        }

        private void FixedUpdate()
        {
            ConstantMoveUp();
            CheckDeleteHeight();
        }

        public override void BalloonBit()
        {
            BalloonSpawner.HideBalloon(this);
            RandomizationStartPosition();
            SurpriseBalloonBit?.Invoke();
        }
    }
}
