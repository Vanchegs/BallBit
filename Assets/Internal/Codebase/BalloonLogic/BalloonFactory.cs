using System.Collections;
using UnityEngine;

namespace Internal.Codebase.BalloonLogic
{
    public class BalloonFactory : MonoBehaviour, IBalloonFactory
    {
        private const byte PoolSize = 20;
        private const int BangBalloonsSpawnRate = 3;

        public BalloonPool<Balloon> BalloonPool;
        public BalloonPool<BangBalloon> BangBalloonPool;

        private const int BalloonsSpawnRate = 1;
        
        [SerializeField] private Balloon balloon;
        [SerializeField] private BangBalloon bangBalloon;
        [SerializeField] private Transform balloonContainer;

        private void Start()
        {
            BalloonPool = new BalloonPool<Balloon>(balloon, balloonContainer, PoolSize, true);
            BangBalloonPool = new BalloonPool<BangBalloon>(bangBalloon, balloonContainer, PoolSize, true);

            StartCoroutine(SpawnBalloons());
            StartCoroutine(SpawnBangBalloons());
        }

        public IEnumerator SpawnBalloons()
        {
            while (true)
            {
                BalloonPool.GetFree();
                yield return new WaitForSeconds(BalloonsSpawnRate);
            }
        }

        public IEnumerator SpawnBangBalloons()
        {
            while (true)
            {
                BangBalloonPool.GetFree();
                yield return new WaitForSeconds(BangBalloonsSpawnRate);
            }
        }
    }
}
