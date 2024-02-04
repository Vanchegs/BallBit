using System;
using UnityEngine;

namespace Internal.Codebase.UILogic
{
    public class CameraFinder : MonoBehaviour
    {
        private Camera mainCamera;
        private Canvas canvas;
        
        private void Start()
        {
            mainCamera = Camera.main;
            canvas = GetComponent<Canvas>();

            canvas.worldCamera = mainCamera;
        }
    }
}
