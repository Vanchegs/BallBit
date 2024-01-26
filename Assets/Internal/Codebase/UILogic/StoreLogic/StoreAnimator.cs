using DG.Tweening;
using UnityEngine;

namespace Internal.Codebase.UILogic.StoreLogic
{
    public class StoreAnimator : MonoBehaviour
    {
        public void MoveStore()
        {
            transform.DOMoveX(2, 1, false);
        }
    }
}
