using UnityEngine;
using UnityEngine.Events;

namespace Internal.Codebase.BalloonLogic.BalloonBitLogic
{
    public class ClickDetection : MonoBehaviour
    {
        [HideInInspector] public UnityEvent onClick;

        public void OnMouseDown() => onClick.Invoke();
    }
}
