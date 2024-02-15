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
        private const float BalloonsSpawnRate = 0.7f;
        private const int BalloonQuantity = 10;

        private IBalloonFactory balloonFactory;

        [Header("Data For Balloons")]
        [SerializeField] private BalloonsConfig balloonsConfig;
        [SerializeField] private Transform balloonContainer;

        private void Start()
        {
            balloonFactory = new BalloonFactory(balloonsConfig, balloonContainer, BalloonQuantity);
            balloonFactory.InitPools();
            
            CoroutineStarting();
        }
        
        private void OnEnable() => 
            GameEventBus.OnHideBalloon += BalloonHide;
         
        private void OnDisable() => 
            GameEventBus.OnHideBalloon -= BalloonHide;

        private void CoroutineStarting()
        {
            StartCoroutine(SpawnOrdinaryBalloons());
            StartCoroutine(SpawnSurpriseBalloons());
        }
        
        private void BalloonHide(Balloon balloon) => 
            balloonFactory.ReturnBalloonInPool(balloon);

        private IEnumerator SpawnOrdinaryBalloons()
        {
            while (true)
            {
                balloonFactory.GetFreeBalloon(typeof(OrdinaryBalloon));
                yield return new WaitForSeconds(BalloonsSpawnRate);
            }
        }

        private IEnumerator SpawnSurpriseBalloons()
        {
            while (true)
            {
                balloonFactory.GetFreeBalloon(typeof(SurpriseBalloon));
                yield return new WaitForSeconds(SurpriseBalloonsSpawnRate);
            }
        }
    }
}
