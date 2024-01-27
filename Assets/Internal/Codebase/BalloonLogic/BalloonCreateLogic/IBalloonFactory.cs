using Internal.Codebase.BalloonLogic.Balloons;

namespace Internal.Codebase.BalloonLogic.BalloonCreateLogic
{
    public interface IBalloonFactory
    {
        public void InitPools();

        public void DisableAllPools();

        public void GetFreeBalloon(string typeOfBalloon);

        public void ReturnBalloonInPool(Balloon balloon);
    }
}