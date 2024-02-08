using Internal.Codebase.BalloonLogic.BalloonCreateLogic;
using Internal.Codebase.Common;
using Internal.Codebase.Infrastructure;
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
            GameEventBus.OnHideBalloon(this);
            RandomizationStartPosition();
            GameEventBus.OnSurpriseBalloonBit?.Invoke();
        }
    }
}
