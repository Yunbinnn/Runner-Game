using UnityEngine;
using UnityEngine.Events;

public class RoadBox : CollisionObject
{
    [SerializeField] UnityEvent callBack;

    public override void Activate(Runner runner)
    {
        callBack.Invoke();
    }
}