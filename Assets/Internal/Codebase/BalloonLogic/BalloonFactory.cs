using Internal.Codebase.BalloonLogic.Balloons;
using Internal.Codebase.BalloonLogic.BalloonsConfigs;
using Internal.Codebase.Infrastructure;
using UnityEngine;

namespace Internal.Codebase.BalloonLogic
{
    public class BalloonFactory : IBalloonFactory
    {
        private readonly BalloonsConfig balloonsConfig;
        private readonly Transform balloonContainerTransform;
        private readonly int balloonQuantity;

        private BalloonPool<Balloon> balloonPool;
        private BalloonPool<Balloon> bangBalloonPool;

        public BalloonFactory(BalloonsConfig balloonsConfig, Transform balloonContainerTransform, int balloonQuantity)
        {
            this.balloonsConfig = balloonsConfig;
            this.balloonContainerTransform = balloonContainerTransform;
            this.balloonQuantity = balloonQuantity;
        }
        
        public void InitPools()
        {
            balloonPool = new BalloonPool<Balloon>(balloonsConfig.normalBalloonPrefab,
                balloonContainerTransform, balloonQuantity, true);
            bangBalloonPool = new BalloonPool<Balloon>(balloonsConfig.bangBalloonPrefab,
                balloonContainerTransform, balloonQuantity, true);
        }

        public void DisableAllPools()
        {
            balloonPool.DisableAll();
            bangBalloonPool.DisableAll();
        }

        public void GetFreeBalloon(string typeOfBalloon)
        {
            if (typeOfBalloon == Constants.OrdBalloon)
                balloonPool.GetFree();
            else if (typeOfBalloon == Constants.BangBalloon)
                bangBalloonPool.GetFree();
        }

        public void ReturnBalloonInPool(Balloon balloon) => balloonPool.ReturnToPool(balloon);
    }
}