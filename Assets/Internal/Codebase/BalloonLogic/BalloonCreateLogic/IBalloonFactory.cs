using System;
using Internal.Codebase.BalloonLogic.Balloons;

namespace Internal.Codebase.BalloonLogic.BalloonCreateLogic
{
    public interface IBalloonFactory
    { 
        void InitPools();

        void DisableAllPools();

        void GetFreeBalloon(Type typeOfBalloon);

        void ReturnBalloonInPool(Balloon balloon);
    }
}