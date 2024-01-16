using UnityEngine;

namespace Internal.Codebase.BalloonLogic
{
    public class Balloon : MonoBehaviour
    {
        private const float ConstantSpeed = 0.05f;
        
        [SerializeField] private Transform balloonTransform;

        private void FixedUpdate() => ConstantMoveUp();

        private void ConstantMoveUp()
        {
            var input = new Vector3(0, ConstantSpeed, 0);
            balloonTransform.Translate(input);
        }
    }
}