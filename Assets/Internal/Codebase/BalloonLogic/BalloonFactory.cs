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

        BalloonPool = new BalloonPool<Balloon>(this.balloonsConfig.normalBalloonPrefab,
            this.balloonsConfig.spawnPoint, this.balloonsConfig.quantity, true);
        BangBalloonPool = new BalloonPool<BangBalloon>(this.balloonsConfig.bangBalloonPrefab,
            this.balloonsConfig.spawnPoint, this.balloonsConfig.quantity, true);
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
    }
}