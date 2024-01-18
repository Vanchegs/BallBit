using UnityEngine;
using Random = UnityEngine.Random;

namespace Internal.Codebase.BalloonLogic
{
    public class Balloon : MonoBehaviour
    {
        private const float ConstantSpeed = 0.05f;

        private BalloonFactory balloonFactory;

        [SerializeField] private Transform balloonTransform;

        private void Start()
        {
            balloonFactory = FindObjectOfType<BalloonFactory>();
            
            RandomizationStartPosition();
        }

        private void FixedUpdate()
        {
            ConstantMoveUp();
            CheckDeleteHeight();
        }

        private void ConstantMoveUp()
        {
            var input = new Vector3(0, ConstantSpeed, 0);
            balloonTransform.Translate(input);
        }

        private void CheckDeleteHeight()
        {
            if (!(balloonTransform.position.y > 10)) return;
            balloonFactory.BalloonPool.ReturnToPool(this);
            RandomizationStartPosition();
        }

        private void RandomizationStartPosition()
        {
            var xAxis = Random.Range(-8, 8);
            balloonTransform.transform.Translate(new Vector3(xAxis, 0, 0));
        }
    }
}