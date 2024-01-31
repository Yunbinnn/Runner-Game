public class MiddleDetector : CollisionObject
{
    public override void Activate(Runner runner)
    {
        runner.RevertPosition();
    }
}