using Internal.Codebase.CounterLogic;
using UnityEngine;

namespace Internal.Codebase.BalloonLogic.Balloons
{
    public class OrdinaryBalloon : Balloon
    {
        private void Start()
        {
            ConstantSpeed = 0.05f;
            
            Counter = FindObjectOfType<Counter>();
            
            BalloonTransform = GetComponent<Transform>();
            
            RandomizationStartPosition();
        }

        private void FixedUpdate()
        {
            ConstantMoveUp();
            CheckDeleteHeight();
        }
    }
}