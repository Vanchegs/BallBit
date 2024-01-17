using UnityEngine;
using Random = UnityEngine.Random;

namespace Internal.Codebase.BalloonLogic
{
    public class Balloon : MonoBehaviour
    {
        private const float ConstantSpeed = 0.05f;
        
        [SerializeField] private Transform balloonTransform;

        private void Start() => RandomizationStartPosition();

        private void FixedUpdate() => ConstantMoveUp();

        private void ConstantMoveUp()
        {
            var input = new Vector3(0, ConstantSpeed, 0);
            balloonTransform.Translate(input);
        }

        private void RandomizationStartPosition()
        {
            var xAxis = Random.Range(-8, 8);
            balloonTransform.transform.Translate(new Vector3(xAxis, 0, 0));
        }
    }
}