using Internal.Codebase.CounterLogic;
using UnityEngine;

namespace Internal.Codebase.BalloonLogic.Balloons
{
    public class BangBalloon : Balloon
    {
        private void Start()
        {
            ConstantSpeed = 0.08f;
            
            BalloonFactory = FindObjectOfType<BalloonSpawner>();
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
            BalloonFactory.BalloonFactory.ReturnBalloonInPool(this);
            Counter.CountDecrease();
            RandomizationStartPosition();
        }
    }
}
