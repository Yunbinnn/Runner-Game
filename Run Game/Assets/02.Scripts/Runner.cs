using UnityEngine;

public enum RoadLine
{
    LEFT = -1,
    MIDDLE,
    RIGHT,
}

public class Runner : MonoBehaviour
{
    public Animator animator;

    [SerializeField] RoadLine line;
    [SerializeField] RoadLine previousRoadline;
    [SerializeField] float lerpSpd = 2f;

    private readonly float linePosDamp = 2.25f;

    private Vector3 midPos;
    private Vector3 leftPos;
    private Vector3 rightPos;

    void Start()
    {
        midPos = Vector3.zero;
        leftPos = Vector3.left * linePosDamp;
        rightPos = Vector3.right * linePosDamp;

        line = RoadLine.MIDDLE;
        previousRoadline = RoadLine.MIDDLE;
        InputManager.Instance.action += Move;
    }

    void Update()
    {
        Status();
    }

    public void Move()
    {
        if (!GameManager.Instance.state) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (line > RoadLine.LEFT)
            {
                animator.Play("Left Avoid");

                previousRoadline = line;

                line--;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (line < RoadLine.RIGHT)
            {
                animator.Play("Right Avoid");

                previousRoadline = line;

                line++;
            }
        }
    }

    public void Status()
    {
        switch (line)
        {
            case RoadLine.LEFT: Movement(leftPos);
                break;
            case RoadLine.MIDDLE: Movement(midPos);
                break;
            case RoadLine.RIGHT: Movement(rightPos);
                break;
        }
    }

    public void RevertPosition()
    {
        line = previousRoadline;
    }

    public void Movement(Vector3 position)
    {
        transform.position = Vector3.Lerp(transform.position, position, lerpSpd * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<CollisionObject>(out var collision))
        {
            collision.Activate(this);
        }
    }

    private void OnDisable()
    {
        InputManager.Instance.action -= Move;
    }
}