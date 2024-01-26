using System;
using Internal.Codebase.BalloonLogic.BalloonCreateLogic;
using Internal.Codebase.UILogic.CounterLogic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Internal.Codebase.BalloonLogic.Balloons
{
    public abstract class Balloon : MonoBehaviour
    {
        protected float ConstantSpeed { get; set; }

        protected Transform BalloonTransform;
        protected Counter Counter;


        public virtual void BalloonBit()
        {
            BalloonSpawner.HideBalloon(this);
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
            BalloonSpawner.HideBalloon?.Invoke(this);
            RandomizationStartPosition();
        }

        public void RandomizationStartPosition()
        {
            var xAxis = Random.Range(-7, 7);
            BalloonTransform.transform.Translate(new Vector3(xAxis, 0, 0));
        }
    }
}