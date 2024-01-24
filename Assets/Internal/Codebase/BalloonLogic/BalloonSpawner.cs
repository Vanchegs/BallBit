using System.Collections;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.BalloonLogic
{
    public class BalloonSpawner : MonoBehaviour
    {
        private const int BangBalloonsSpawnRate = 3;

        public IBalloonFactory BalloonFactory;

        private const int BalloonsSpawnRate = 1;

        [Inject]
        public void Constructor(IBalloonFactory balloonFactory) =>
            BalloonFactory = balloonFactory;

        private void Start()
        {
            StartCoroutine(SpawnBalloons());
            StartCoroutine(SpawnBangBalloons());
        }

        public IEnumerator SpawnBalloons()
        {
            while (true)
            {
                BalloonFactory.GetFreeBalloon(typeof(Balloon));
                yield return new WaitForSeconds(BalloonsSpawnRate);
            }
        }

        public IEnumerator SpawnBangBalloons()
        {
            while (true)
            {
                BalloonFactory.GetFreeBalloon(typeof(BangBalloon));
                yield return new WaitForSeconds(BangBalloonsSpawnRate);
            }
        }
    }
}
