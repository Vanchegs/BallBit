using Internal.Codebase.BalloonLogic.BalloonCreateLogic;
using Internal.Codebase.Common;
using UnityEngine;

namespace Internal.Codebase.BalloonLogic.Balloons
{
    public class OrdinaryBalloon : Balloon
    {
        private void Start()
        {
            ConstantSpeed = 0.05f;
            
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
            GameEventBus.OrdinaryBalloonBit?.Invoke();
            RandomizationStartPosition();
        }
    }
}