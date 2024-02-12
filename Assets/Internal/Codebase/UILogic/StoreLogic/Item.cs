using System;

namespace Internal.Codebase.UILogic.StoreLogic
{
    [Serializable]
    public class Item
    {
        public Item(int id, bool isBuy, int productPrice)
        {
            IsBuy = isBuy;
            ProductPrice = productPrice;
            Id = id;
        }
        
        public bool IsBuy;

        public int ProductPrice;

        public int Id;
    }
}