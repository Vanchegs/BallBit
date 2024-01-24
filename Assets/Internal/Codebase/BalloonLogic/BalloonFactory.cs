namespace Internal.Codebase.BalloonLogic
{
    public class BalloonFactory
    {
        private const byte PoolSize = 20;
        
        public BalloonPool<Balloon> BalloonPool;
        public BalloonPool<BangBalloon> BangBalloonPool;
    }
}