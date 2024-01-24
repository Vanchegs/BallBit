using UnityEngine;

namespace Internal.Codebase.BalloonLogic.BalloonsConfigs
{
    [CreateAssetMenu(menuName = "BalloonsConfigs/BalloonConfig", fileName = "BalloonConfig", order = 0)]
    public class BalloonConfig : ScriptableObject
    {
        public GameObject BalloonPrefab;
    }
}
