using UnityEngine;

public abstract class CollisionObject : MonoBehaviour
{
    public abstract void Activate(Runner runner);
}