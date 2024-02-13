using System;
using Internal.Codebase.BalloonLogic.Balloons;
using Internal.Codebase.Saves;
using UnityEngine;

namespace Internal.Codebase.Infrastructure
{
    public class GameEventBus : MonoBehaviour
    {
        public static Action OnOrdinaryBalloonBit;
        public static Action OnSurpriseBalloonBit;

        public static Action UpdateCountUI;
        
        public static Action<Balloon> OnHideBalloon;
        
        public static Action<int> OnWalletChange;
        public static Action<int> OnWritingOffCount;

        public static Action<DataForSave> OnLoaded;
    }
}
