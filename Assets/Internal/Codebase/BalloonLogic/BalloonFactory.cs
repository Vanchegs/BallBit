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

        public BalloonPool<Balloon> BalloonPool;
        public BalloonPool<BangBalloon> BangBalloonPool;

        [Inject]
        public BalloonFactory(BalloonsConfig balloonsConfig)
        {
            this.balloonsConfig = balloonsConfig;
            
            InitPools();
            
            Debug.Log("Лох");
        }

        public void InitPools()
        {
            BalloonPool = new BalloonPool<Balloon>(balloonsConfig.normalBalloonPrefab,
                balloonsConfig.spawnPoint, balloonsConfig.quantity, true);
            BangBalloonPool = new BalloonPool<BangBalloon>(balloonsConfig.bangBalloonPrefab,
                balloonsConfig.spawnPoint, balloonsConfig.quantity, true);
        }

        public void DisableAllPools()
        {
            BalloonPool.DisableAll();
            BangBalloonPool.DisableAll();
        }

        public void GetFreeBalloon(Type typeOfBalloon)
        {
            if (typeOfBalloon == typeof(Balloon))
                BalloonPool.GetFree();
            else if (typeOfBalloon == typeof(BangBalloon)) 
                BangBalloonPool.GetFree();
        }

        public void ReturnBalloonToPool(Balloon balloon) => BalloonPool.ReturnToPool(balloon);

        public void ReturnBangBalloonToPool(BangBalloon bangBalloon) => BangBalloonPool.ReturnToPool(bangBalloon);
    }
}