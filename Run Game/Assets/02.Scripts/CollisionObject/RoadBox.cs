using UnityEngine;
using UnityEngine.Events;

public class RoadBox : CollisionObject
{
    [SerializeField] float initSpeed;
    [SerializeField] UnityEvent callBack;
    readonly float offset = 1.75f;

    private void Start()
    {
        initSpeed = GameManager.Instance.speed;
    }

    public override void Activate(Runner runner)
    {
        runner.animator.speed = GameManager.Instance.speed / initSpeed / offset;

        callBack.Invoke();

        GameManager.Instance.IncreaseSpeed();
    }
}