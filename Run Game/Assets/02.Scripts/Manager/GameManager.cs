public class GameManager : Singleton<GameManager>
{
    public float limit = 45f;
    public float speed = 18f;
    public bool state = true;

    public void GameOver()
    {
        state = false;
    }

    public void IncreaseSpeed()
    {
        if(speed < limit)
        {
            speed += 1;
        }
    }
}