using Internal.Codebase.Infrastructure;
using UnityEngine;

namespace Internal.Codebase.UILogic.StoreLogic
{
    public class ShopItem : MonoBehaviour
    {
        public int id;
        
        private ShopSign shopSign;
        
        [field: SerializeField] public bool IsBuy { get; private set; }
        
        [field: SerializeField] public int ProductPrice { get; private set; }

        private void Start() => 
            shopSign = GetComponent<ShopSign>();

        public void TryBuy()
        {
            if (StoreWallet.Wallet.WalletCount >= ProductPrice)
            {
                switch (IsBuy)
                {
                    case false:
                        Buy();
                        break;
                    
                    default:
                        return;
                }
            }
        }

        private void Buy()
        {
            IsBuy = true;
            
            GameEventBus.OnWritingOffCount?.Invoke(ProductPrice);
                                    
            shopSign.CheckIsBuy();
        }
    }
}
