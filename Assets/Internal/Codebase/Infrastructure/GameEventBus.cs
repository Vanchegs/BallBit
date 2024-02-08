using System;
using Internal.Codebase.BalloonLogic.Balloons;
using UnityEngine;

namespace Internal.Codebase.Infrastructure
{
    public class GameEventBus : MonoBehaviour
    {
        public static Action OnOrdinaryBalloonBit;
        public static Action OnSurpriseBalloonBit;
        
        public static Action<Balloon> OnHideBalloon;
        
        public static Action<int> OnWalletChange;
        public static Action<int> OnWritingOffCount;
    }
}
