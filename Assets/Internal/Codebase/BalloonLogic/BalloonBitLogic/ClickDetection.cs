using UnityEngine;
using UnityEngine.Events;

namespace Internal.Codebase.BalloonLogic.BalloonBitLogic
{
    public class ClickDetection : MonoBehaviour
    {
        public UnityEvent onClick;

        private void OnMouseDown() => onClick.Invoke();
    }
}
