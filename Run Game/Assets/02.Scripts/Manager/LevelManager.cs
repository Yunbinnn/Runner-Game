using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static float spawnTime = 2.5f;
    [SerializeField] float decreaseTime = 0.075f;
    
    public void ControlLevel()
    {
        if (spawnTime > 0.25f)
        {
            spawnTime -= decreaseTime;
        }
    }
}