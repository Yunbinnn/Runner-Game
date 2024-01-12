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

    void Start()
    {
        line = RoadLine.MIDDLE;
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (line <= RoadLine.LEFT)
            {
                line = RoadLine.LEFT;
            }
            else line--;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (line >= RoadLine.RIGHT)
            {
                line = RoadLine.RIGHT;
            }
            else line++;
        }
    }
}