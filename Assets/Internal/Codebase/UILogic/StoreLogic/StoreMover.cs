
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Internal.Codebase.UILogic.StoreLogic
{
    public class StoreMover : MonoBehaviour
    {
        private bool isStoreActivate;

        [SerializeField] private GameObject storeCatalog;
        [SerializeField] private RectTransform startPosition;
        [SerializeField] private RectTransform finalPosition;

        public void MoveStore()
        {
            if (isStoreActivate == false)
            {
                transform.DOMoveX(finalPosition.position.x, 1, false);
                isStoreActivate = true;
            }
            else
            {
                transform.DOMoveX(startPosition.position.x, 1, false);
                isStoreActivate = false;
            }
        }
    }
}
