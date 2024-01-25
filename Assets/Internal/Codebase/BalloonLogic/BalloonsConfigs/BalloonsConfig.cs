using Internal.Codebase.BalloonLogic.Balloons;
using UnityEngine;

namespace Internal.Codebase.BalloonLogic.BalloonsConfigs
{
    [CreateAssetMenu(menuName = "BalloonsConfigs/BalloonConfig", fileName = "BalloonConfig", order = 0)]
    public class BalloonsConfig : ScriptableObject
    {
        public OrdinaryBalloon normalBalloonPrefab;

        public BangBalloon bangBalloonPrefab;
    }
}
