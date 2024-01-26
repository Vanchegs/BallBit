using DG.Tweening;
using UnityEngine;

namespace Internal.Codebase.UILogic.StoreLogic
{
    public class StoreAnimator : MonoBehaviour
    {
        private bool isStoreActivate;
        
        public void MoveStore()
        {
            if (isStoreActivate == false)
            {
                transform.DOMoveX(0, 1, false);
                isStoreActivate = true;
            }
            else
            {
                transform.DOMoveX(17.8f, 1, false);
                isStoreActivate = false;
            }
        }
    }
}
