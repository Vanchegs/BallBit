using System.Collections.Generic;
using UnityEngine;

namespace Internal.Codebase.Saves
{
    public class DataForSave : MonoBehaviour
    {
        public int WalletCount { get; set; }
        
        public Dictionary<string, bool> ShopItemsForSave;
    }
}
