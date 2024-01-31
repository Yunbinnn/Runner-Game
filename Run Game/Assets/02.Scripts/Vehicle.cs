using UnityEngine;

public class Vehicle : CollisionObject
{
    [SerializeField] Vector3 direction;
    private float speed;

    [SerializeField] float minRandomSpeed = 5f;
    [SerializeField] float maxRandomSpeed = 20f;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    void Start()
    {
        if (minRandomSpeed < 19)
        {
            minRandomSpeed += 1;
        }

        direction = Vector3.back;
        Speed = GameManager.Instance.speed + Random.Range(minRandomSpeed, maxRandomSpeed);
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