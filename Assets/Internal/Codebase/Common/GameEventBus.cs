using System;
using Internal.Codebase.BalloonLogic.Balloons;
using UnityEngine;

namespace Internal.Codebase.Common
{
    public class GameEventBus : MonoBehaviour
    {
        public static Action OrdinaryBalloonBit;
        public static Action SurpriseBalloonBit;
        
        public static Action<Balloon> HideBalloon;
        
        public static Action<int> WalletChange;
    }
}
