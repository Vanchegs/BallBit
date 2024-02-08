using UnityEngine;

namespace Internal.Codebase.UILogic.StoreLogic
{
    public class ShopItem : MonoBehaviour
    {
        private ShopSign shopSign;
        
        [field: SerializeField] public bool IsBuy { get; private set; }
        
        [field: SerializeField] public int ProductPrice { get; private set; }
        

        [SerializeField] private StoreWallet storeWallet;

        private void Start() => 
            shopSign = GetComponent<ShopSign>();

        public void TryBuy()
        {
            if (storeWallet.WalletCount >= ProductPrice)
            {
                Buy();
                
                shopSign.CheckIsBuy();
            }
        }

        private void Buy() =>
            IsBuy = true;
    }
}
