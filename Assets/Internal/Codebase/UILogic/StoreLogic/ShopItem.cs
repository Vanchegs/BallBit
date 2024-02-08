using Internal.Codebase.Infrastructure;
using UnityEngine;

namespace Internal.Codebase.UILogic.StoreLogic
{
    public class ShopItem : MonoBehaviour
    {
        private ShopSign shopSign;
        
        [field: SerializeField] public bool IsBuy { get; private set; }
        
        [field: SerializeField] public int ProductPrice { get; private set; }

        private void Start() => 
            shopSign = GetComponent<ShopSign>();

        public void TryBuy()
        {
            if (StoreWallet.Wallet.WalletCount >= ProductPrice)
            {
                Buy();
                
                GameEventBus.OnWritingOffCount?.Invoke(ProductPrice);
                
                shopSign.CheckIsBuy();
            }
        }

        private void Buy() =>
            IsBuy = true;
    }
}
