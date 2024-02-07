using System;
using Internal.Codebase.BalloonLogic.BalloonCreateLogic;
using Internal.Codebase.Common;
using Internal.Codebase.Infrastructure;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Internal.Codebase.BalloonLogic.Balloons
{
    public abstract class Balloon : MonoBehaviour
    {
        protected float ConstantSpeed { get; set; }

        protected Transform BalloonTransform;

        public virtual void BalloonBit()
        {
            GameEventBus.HideBalloon(this);
            
            RandomizationStartPosition();
        }

        private void BalloonDestroy()
        {
            GameEventBus.HideBalloon(this);
            RandomizationStartPosition();
        }

        protected void ConstantMoveUp()
        {
            var input = new Vector3(0, ConstantSpeed, 0);
            BalloonTransform.Translate(input);
        }

        protected void CheckDeleteHeight()
        {
            if (!(BalloonTransform.position.y > 10)) return;
            GameEventBus.HideBalloon?.Invoke(this);
            RandomizationStartPosition();
        }

        protected void RandomizationStartPosition()
        {
            var xAxis = Random.Range(-7, 7);
            BalloonTransform.transform.Translate(new Vector3(xAxis, 0, 0));
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(Constants.BalloonTag)) 
                BalloonDestroy();
        }
    }
}