using System.Collections;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.BalloonLogic
{
    public class BalloonSpawner : MonoBehaviour
    {
        private const int BangBalloonsSpawnRate = 3;

        public BalloonFactory BalloonFactory;

        private const int BalloonsSpawnRate = 1;

        [Inject]
        public void Constructor(BalloonFactory balloonFactory) =>
            BalloonFactory = balloonFactory;

        private void Start()
        {
        }

        public IEnumerator SpawnBalloons()
        {
            while (true)
            {
                BalloonFactory.BalloonPool.GetFree();
                yield return new WaitForSeconds(BalloonsSpawnRate);
            }
        }

        public IEnumerator SpawnBangBalloons()
        {
            while (true)
            {
                BalloonFactory.BangBalloonPool.GetFree();
                yield return new WaitForSeconds(BangBalloonsSpawnRate);
            }
        }
    }
}
