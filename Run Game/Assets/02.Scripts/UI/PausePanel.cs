using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public void Resume()
    {
        Time.timeScale = 1.0f;

        gameObject.SetActive(false);
    }

    public void Settings()
    {

    }

    public void Exit()
    {
        StartCoroutine(AsyncSceneLoader.Instance.AsyncLoad(SceneID.TITLE));
    }
}