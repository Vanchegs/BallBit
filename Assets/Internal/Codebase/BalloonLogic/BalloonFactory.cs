using System;
using Internal.Codebase.BalloonLogic.BalloonsConfigs;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.BalloonLogic
{
    public class BalloonFactory : IBalloonFactory
    {
        private BalloonsConfig balloonsConfig;
        private Transform balloonContainer;

        private BalloonPool<Balloon> balloonPool;
        private BalloonPool<BangBalloon> bangBalloonPool;

        [Inject]
        public BalloonFactory(BalloonsConfig balloonsConfig)
        {
            this.balloonsConfig = balloonsConfig;
            
            InitPools();
            
            Debug.Log("Лох");
        }

        public void InitPools()
        {
            balloonPool = new BalloonPool<Balloon>(balloonsConfig.normalBalloonPrefab,
                balloonsConfig.spawnPoint, balloonsConfig.quantity, true);
            bangBalloonPool = new BalloonPool<BangBalloon>(balloonsConfig.bangBalloonPrefab,
                balloonsConfig.spawnPoint, balloonsConfig.quantity, true);
        }

        public void DisableAllPools()
        {
            balloonPool.DisableAll();
            bangBalloonPool.DisableAll();
        }

        public void GetFreeBalloon(Type typeOfBalloon)
        {
            if (typeOfBalloon == typeof(Balloon))
                balloonPool.GetFree();
            else if (typeOfBalloon == typeof(BangBalloon)) 
                bangBalloonPool.GetFree();
        }

        public void ReturnBalloonToPool(Balloon balloon) => balloonPool.ReturnToPool(balloon);

        public void ReturnBangBalloonToPool(BangBalloon bangBalloon) => bangBalloonPool.ReturnToPool(bangBalloon);
    }
}