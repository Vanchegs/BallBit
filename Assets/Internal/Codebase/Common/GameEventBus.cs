using System;
using UnityEngine;

namespace Internal.Codebase.Common
{
    public class GameEventBus : MonoBehaviour
    {
        public static Action OrdinaryBalloonBit;
        public static Action SurpriseBalloonBit;
        
        public static Action<int> WalletChange;
    }
}
