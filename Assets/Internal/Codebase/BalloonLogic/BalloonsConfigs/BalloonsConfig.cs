using Internal.Codebase.BalloonLogic.Balloons;
using UnityEngine;

namespace Internal.Codebase.BalloonLogic.BalloonsConfigs
{
    [CreateAssetMenu(menuName = "BalloonsConfigs/BalloonsConfig", fileName = "BalloonsConfig", order = 0)]
    public class BalloonsConfig : ScriptableObject
    {
        public OrdinaryBalloon normalBalloonPrefab;

        public SurpriseBalloon surpriseBalloonPrefab;
    }
}
