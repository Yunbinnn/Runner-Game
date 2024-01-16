using UnityEngine;

public class Vehicle : CollisionObject
{
    [SerializeField] Vector3 direction;
    [SerializeField] float speed = 5.0f;

    void Start()
    {
        direction = Vector3.right;
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction);
    }

    public override void Activate(Runner runner)
    {
        Debug.Log("Game Over");
    }
}