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

    private static readonly float linePosDamp = 2f;

    Vector3 leftPos = Vector3.left * linePosDamp;
    Vector3 midPos = Vector3.zero;
    Vector3 rightPos = Vector3.right * linePosDamp;

    void Start()
    {
        line = RoadLine.MIDDLE;
    }

    void Update()
    {
        Move();

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
                Movement(-linePosDamp);
                break;
            case RoadLine.MIDDLE:
                Movement(0);
                break;
            case RoadLine.RIGHT:
                Movement(linePosDamp);
                break;
        }
    }

    public void Movement(float position)
    {
        transform.position = new Vector3(Mathf.Lerp(transform.localPosition.x,
                                    position, lerpSpd * Time.deltaTime), 0, 0);
    }
}