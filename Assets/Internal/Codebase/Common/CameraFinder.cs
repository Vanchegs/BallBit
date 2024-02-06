using UnityEngine;

namespace Internal.Codebase.Common
{
    public class CameraFinder : MonoBehaviour
    {
        private Camera mainCamera;
        private Canvas canvas;
        
        private void Start()
        {
            canvas = GetComponent<Canvas>();
            
            mainCamera = Camera.main;

            CameraFinding(mainCamera, canvas);
        }

        private void CameraFinding(Camera camera, Canvas canvas) => 
            canvas.worldCamera = camera;
    }
}
