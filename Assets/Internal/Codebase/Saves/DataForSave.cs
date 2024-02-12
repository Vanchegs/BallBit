using System;
using System.Collections.Generic;
using Internal.Codebase.UILogic.StoreLogic;

namespace Internal.Codebase.Saves
{
    [Serializable]
    public class DataForSave
    {
        public int Currency;
        
        public List<Item> ItemsForSave;
    }
}
