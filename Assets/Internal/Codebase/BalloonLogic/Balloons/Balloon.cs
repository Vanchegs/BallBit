using Internal.Codebase.CounterLogic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Internal.Codebase.BalloonLogic.Balloons
{
    public abstract class Balloon : MonoBehaviour
    {
        protected float ConstantSpeed { get; set; }

        protected BalloonSpawner BalloonFactory;
        protected Transform BalloonTransform;
        protected Counter Counter;

        private void Start()
        {
            BalloonFactory = FindObjectOfType<BalloonSpawner>();
            Counter = FindObjectOfType<Counter>();
            
            BalloonTransform = GetComponent<Transform>();
        }

        public void BalloonBit()
        {
            BalloonFactory.BalloonFactory.ReturnBalloonInPool(this);
            Counter.CountIncrease();
            RandomizationStartPosition();
        }

        public void ConstantMoveUp()
        {
            var input = new Vector3(0, ConstantSpeed, 0);
            BalloonTransform.Translate(input);
        }

        public void CheckDeleteHeight()
        {
            if (!(BalloonTransform.position.y > 10)) return;
            BalloonFactory.BalloonFactory.ReturnBalloonInPool(this);
            RandomizationStartPosition();
        }

        public void RandomizationStartPosition()
        {
            var xAxis = Random.Range(-8, 8);
            BalloonTransform.transform.Translate(new Vector3(xAxis, 0, 0));
        }
    }
}