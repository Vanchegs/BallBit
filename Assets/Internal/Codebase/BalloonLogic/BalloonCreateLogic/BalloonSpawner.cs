using System;
using System.Collections;
using Internal.Codebase.BalloonLogic.Balloons;
using Internal.Codebase.BalloonLogic.BalloonsConfigs;
using Internal.Codebase.Infrastructure;
using UnityEngine;

namespace Internal.Codebase.BalloonLogic.BalloonCreateLogic
{
    public class BalloonSpawner : MonoBehaviour
    {
        private const int SurpriseBalloonsSpawnRate = 3;
        private const int BalloonsSpawnRate = 1;
        private const int BalloonQuantity = 20;

        private IBalloonFactory balloonFactory;

        [Header("Data For Balloons")]
        [SerializeField] private BalloonsConfig balloonsConfig;
        [SerializeField] private Transform balloonContainer;

        public static Action<Balloon> HideBalloon;

        private void Start()
        {
            balloonFactory = new BalloonFactory(balloonsConfig, balloonContainer, BalloonQuantity);
            balloonFactory.InitPools();
            
            StartCoroutine(SpawnOrdinaryBalloons());
            StartCoroutine(SpawnSurpriseBalloons());
        }
        
        private void OnEnable() => 
            HideBalloon += BalloonHide;

        private void OnDisable() => 
            HideBalloon -= BalloonHide;

        private void BalloonHide(Balloon balloon) => 
            balloonFactory.ReturnBalloonInPool(balloon);

        public IEnumerator SpawnOrdinaryBalloons()
        {
            while (true)
            {
                balloonFactory.GetFreeBalloon(Constants.OrdBalloon);
                yield return new WaitForSeconds(BalloonsSpawnRate);
            }
        }

        public IEnumerator SpawnSurpriseBalloons()
        {
            while (true)
            {
                balloonFactory.GetFreeBalloon(Constants.SurpBalloon);
                yield return new WaitForSeconds(SurpriseBalloonsSpawnRate);
            }
        }
    }
}
