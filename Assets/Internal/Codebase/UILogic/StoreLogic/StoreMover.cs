using DG.Tweening;
using UnityEngine;
using YG;

namespace Internal.Codebase.UILogic.StoreLogic
{
    public class StoreMover : MonoBehaviour
    {
        private bool isStoreActivate;

        [SerializeField] private RectTransform startPosition;
        [SerializeField] private RectTransform finalPosition;

        public void MoveStore()
        {
            if (isStoreActivate == false)
            {
                transform.DOMoveX(finalPosition.position.x, 1, false);
                isStoreActivate = true;
                YandexGame.FullscreenShow();
            }
            else
            {
                transform.DOMoveX(startPosition.position.x, 1, false);
                isStoreActivate = false;
            }
        }
    }
}
