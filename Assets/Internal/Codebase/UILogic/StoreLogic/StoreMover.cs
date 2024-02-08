
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Internal.Codebase.UILogic.StoreLogic
{
    public class StoreMover : MonoBehaviour
    {
        private bool isStoreActivate;

        [SerializeField] private GameObject storeCatalog;

        private void Start() =>
            storeCatalog.SetActive(false);

        public async void MoveStore()
        {
            if (isStoreActivate == false)
            {
                storeCatalog.SetActive(true);
                
                transform.DOMoveX(0, 1, false);
                isStoreActivate = true;
            }
            else
            {
                transform.DOMoveX(17.78f, 1f, false);
                isStoreActivate = false;

                await Task.Delay(800);
                
                if (isStoreActivate == false)
                    storeCatalog.SetActive(false);
            }
        }
    }
}
