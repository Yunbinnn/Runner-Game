using UnityEngine;

public enum RoadLine
{
    LEFT = -1,
    MIDDLE,
    RIGHT,
}

public class Runner : MonoBehaviour
{
    [SerializeField] RoadLine line;
    [SerializeField] float lerpSpd = 2f;

    private readonly float linePosDamp = 2.25f;

    private Vector3 midPos;
    private Vector3 leftPos;
    private Vector3 rightPos;

    private void OnEnable()
    {
        InputManager.instance.action += Move;
    }

    void Start()
    {
        line = RoadLine.MIDDLE;

        midPos = Vector3.zero;
        leftPos = Vector3.left * linePosDamp;
        rightPos = Vector3.right * linePosDamp;
    }

    void Update()
    {
        Status();
    }

    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (line > RoadLine.LEFT)
            {
                line--;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (line < RoadLine.RIGHT)
            {
                line++;
            }
        }
    }

    public void Status()
    {
        switch (line)
        {
            case RoadLine.LEFT:
                Movement(leftPos);
                break;
            case RoadLine.MIDDLE:
                Movement(midPos);
                break;
            case RoadLine.RIGHT:
                Movement(rightPos);
                break;
        }
    }

    public void Movement(Vector3 position)
    {
        transform.position = Vector3.Lerp(transform.position, position, lerpSpd * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        CollisionObject collision = other.GetComponent<CollisionObject>();

        if(collision != null)
        {
            collision.Activate(this);
        }
    }

    private void OnDisable()
    {
        InputManager.instance.action -= Move;
    }
}