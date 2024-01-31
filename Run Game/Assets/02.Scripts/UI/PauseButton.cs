using UnityEngine;

public class PauseButton : MonoBehaviour
{
    private GameObject panel;
    private Transform parent;

    private void Start()
    {
        parent = GameObject.Find("UI Canvas").GetComponent<Transform>();
    }

    public void Pause()
    {
        Time.timeScale = 0f;

        if (panel == null)
        {
            panel = Instantiate(Resources.Load<GameObject>("Pause Panel"), parent);
        }
        else panel.SetActive(true);
    }
}