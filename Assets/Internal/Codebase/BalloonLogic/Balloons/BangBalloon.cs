using Internal.Codebase.CounterLogic;
using UnityEngine;

namespace Internal.Codebase.BalloonLogic.Balloons
{
    public class BangBalloon : Balloon
    {
        private BalloonSpawner balloonFactory;
        private Transform balloonTransform;
        private Counter counter;

        private void Start()
        {
            ConstantSpeed = 0.08f;
            
            RandomizationStartPosition();
        }

        private void FixedUpdate()
        {
            ConstantMoveUp();
            CheckDeleteHeight();
        }
    }
}
