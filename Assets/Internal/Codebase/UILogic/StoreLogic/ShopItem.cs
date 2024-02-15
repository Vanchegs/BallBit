using UnityEngine;

namespace Internal.Codebase.UILogic.StoreLogic
{
    public class ShopItem : MonoBehaviour
    {
        public ShopSign shopSign;
        
        [field: SerializeField] public int Id { get; private set; }
        [field: SerializeField] public bool IsBuy { get; private set; }
        [field: SerializeField] public int ProductPrice { get; private set; }

        private void Start() =>
            shopSign = GetComponent<ShopSign>();
    }
}
