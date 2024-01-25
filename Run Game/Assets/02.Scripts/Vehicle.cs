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
        direction = Vector3.back;
        Speed = GameManager.Instance.speed + Random.Range(5, 15);
    }

    void Update()
    {
        if (!GameManager.Instance.state) return;

        transform.Translate(speed * Time.deltaTime * direction);
    }

    public override void Activate(Runner runner)
    {
        runner.animator.Play("Die");

        GameManager.Instance.GameOver();
    }
}