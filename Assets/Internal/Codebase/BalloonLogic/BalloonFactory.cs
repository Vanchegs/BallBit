using System;
using Internal.Codebase.BalloonLogic.Balloons;
using Internal.Codebase.BalloonLogic.BalloonsConfigs;
using Internal.Codebase.Infrastructure;
using UnityEngine;

namespace Internal.Codebase.BalloonLogic
{
    public class BalloonFactory : IBalloonFactory
    {
        private BalloonsConfig balloonsConfig;

        private BalloonPool<Balloon> balloonPool;
        private BalloonPool<Balloon> bangBalloonPool;

        public BalloonFactory(BalloonsConfig balloonsConfig)
        {
            this.balloonsConfig = balloonsConfig;
        }
        
        public void InitPools()
        {
            Debug.Log(balloonsConfig);
            
            balloonPool = new BalloonPool<Balloon>(balloonsConfig.normalBalloonPrefab,
                balloonsConfig.spawnPoint, balloonsConfig.quantity, true);
            bangBalloonPool = new BalloonPool<Balloon>(balloonsConfig.bangBalloonPrefab,
                balloonsConfig.spawnPoint, balloonsConfig.quantity, true);
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