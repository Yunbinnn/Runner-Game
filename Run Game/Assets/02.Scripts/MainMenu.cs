using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Button startButton;

    public void Excute()
    {
        animator.SetTrigger("Start");

        startButton.interactable = false;

        StartCoroutine(AsyncSceneLoader.Instance.AsyncLoad(SceneID.GAME));
    }
}