namespace Internal.Codebase.BalloonLogic.Balloons
{
    public class OrdinaryBalloon : Balloon
    {
        private void Start()
        {
            RandomizationStartPosition();
        }

        private void FixedUpdate()
        {
            ConstantMoveUp();
            CheckDeleteHeight();
        }
    }
}