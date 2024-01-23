using UnityEngine;

public class Vehicle : CollisionObject
{
    [SerializeField] Vector3 direction;
    private float speed;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    void Start()
    {
        Speed = Random.Range(5, 15);
        direction = Vector3.back;
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