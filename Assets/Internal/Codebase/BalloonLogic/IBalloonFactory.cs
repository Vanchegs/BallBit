using System.Collections;

namespace Internal.Codebase.BalloonLogic
{
    public interface IBalloonFactory
    {
        public IEnumerator SpawnBalloons();

        public IEnumerator SpawnBangBalloons();
    }
}