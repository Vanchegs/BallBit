using Internal.Codebase.BalloonLogic.BalloonCreateLogic;
using Internal.Codebase.CounterLogic;
using UnityEngine;

namespace Internal.Codebase.BalloonLogic.Balloons
{
    public class SurpriseBalloon : Balloon
    {
        private void Start()
        {
            ConstantSpeed = 0.08f;
            
            Counter = FindObjectOfType<Counter>();
            
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
            Counter.CountRandomChange();
            RandomizationStartPosition();
        }
    }
}
