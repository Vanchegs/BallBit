using System;

namespace Internal.Codebase.BalloonLogic
{
    public interface IBalloonFactory
    {
        public void InitPools();

        public void DisableAllPools();

        public void GetFreeBalloon(Type typeOfBalloon);

        public void ReturnBalloonToPool(Balloon balloon);

        public void ReturnBangBalloonToPool(BangBalloon bangBalloon);
    }
}