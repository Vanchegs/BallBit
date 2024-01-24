using Internal.Codebase.CounterLogic;
using UnityEngine;

namespace Internal.Codebase.BalloonLogic
{
    public class BangBalloon : MonoBehaviour, IBalloon
    {
        private const float ConstantSpeed = 0.08f;

        private BalloonSpawner balloonFactory;
        private Transform balloonTransform;
        private Counter counter;

        private void Start()
        {
            balloonFactory = FindObjectOfType<BalloonSpawner>();
            counter = FindObjectOfType<Counter>();
            
            balloonTransform = GetComponent<Transform>();
            
            RandomizationStartPosition();
        }

        private void FixedUpdate()
        {
            ConstantMoveUp();
            CheckDeleteHeight();
        }

        public void BalloonBit()
        {
            balloonFactory.BalloonFactory.ReturnBangBalloonToPool(this);
            counter.CountDecrease();
            RandomizationStartPosition();
        }

        public void ConstantMoveUp()
        {
            var input = new Vector3(0, ConstantSpeed, 0);
            balloonTransform.Translate(input);
        }

        public void CheckDeleteHeight()
        {
            if (!(balloonTransform.position.y > 10)) return;
            balloonFactory.BalloonFactory.ReturnBangBalloonToPool(this);
            RandomizationStartPosition();
        }

        public void RandomizationStartPosition()
        {
            var xAxis = Random.Range(-8, 8);
            balloonTransform.transform.Translate(new Vector3(xAxis, 0, 0));
        }
    }
}
