using UnityEngine;

namespace Internal.Codebase.BalloonLogic.BalloonsConfigs
{
    [CreateAssetMenu(menuName = "BalloonsConfigs/BalloonConfig", fileName = "BalloonConfig", order = 0)]
    public class BalloonsConfig : ScriptableObject
    {
        public Balloon normalBalloonPrefab;

        public BangBalloon bangBalloonPrefab;

        public Transform spawnPoint;

        public int quantity;
    }
}
