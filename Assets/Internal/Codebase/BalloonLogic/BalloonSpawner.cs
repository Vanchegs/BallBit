using System;
using System.Collections;
using Internal.Codebase.BalloonLogic.Balloons;
using Internal.Codebase.BalloonLogic.BalloonsConfigs;
using Internal.Codebase.Infrastructure;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.BalloonLogic
{
    public class BalloonSpawner : MonoBehaviour
    {
        private const int BangBalloonsSpawnRate = 3;
        private const int BalloonsSpawnRate = 1;
        private const int BalloonQuantity = 20;
        
        public IBalloonFactory BalloonFactory;

        [SerializeField] private BalloonsConfig balloonsConfig;
        [SerializeField] private Transform balloonContainer;

        public static Action<Balloon> HideBalloon;

        private void Start()
        {
            BalloonFactory = new BalloonFactory(balloonsConfig, balloonContainer, BalloonQuantity);
            BalloonFactory.InitPools();
            
            StartCoroutine(SpawnBalloons());
            StartCoroutine(SpawnBangBalloons());
        }

        public IEnumerator SpawnBalloons()
        {
            while (true)
            {
                BalloonFactory.GetFreeBalloon(Constants.OrdBalloon);
                yield return new WaitForSeconds(BalloonsSpawnRate);
            }
        }

        public IEnumerator SpawnBangBalloons()
        {
            while (true)
            {
                BalloonFactory.GetFreeBalloon(Constants.BangBalloon);
                yield return new WaitForSeconds(BangBalloonsSpawnRate);
            }
        }
    }
}
