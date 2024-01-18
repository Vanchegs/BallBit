using System.Collections;
using UnityEngine;

namespace Internal.Codebase.BalloonLogic
{
    public class BalloonFactory : MonoBehaviour
    {
        private const byte PoolSize = 50;
        private const int SpawnRate = 1;

        public BalloonPool<Balloon> BalloonPool;

        [SerializeField] private Balloon balloon;
        [SerializeField] private Transform balloonContainer;

        private void Start()
        {
            BalloonPool = new BalloonPool<Balloon>(balloon, balloonContainer, PoolSize, true);

            StartCoroutine(SpawnBalloons());
        }

        private IEnumerator SpawnBalloons()
        {
            while (true)
            {
                BalloonPool.GetFree();
                yield return new WaitForSeconds(SpawnRate);
            }
        }
    }
}
