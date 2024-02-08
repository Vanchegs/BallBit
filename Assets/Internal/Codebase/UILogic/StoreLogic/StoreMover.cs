using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Internal.Codebase.UILogic.StoreLogic
{
    public class StoreMover : MonoBehaviour
    {
        private Image storeUi;
        private bool isStoreActivate;

        private void Start()
        {
            storeUi = GetComponent<Image>();
        }

        public async void MoveStore()
        {
            if (isStoreActivate == false)
            {
                transform.DOMoveX(0, 1, false);
                isStoreActivate = true;
            }
            else
            {
                transform.DOMoveX(17.78f, 1, false);
                isStoreActivate = false;
            }
        }
    }
}
