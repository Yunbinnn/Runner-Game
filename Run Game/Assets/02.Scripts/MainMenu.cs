using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void Excute()
    {
        animator.SetTrigger("Start");

        StartCoroutine(AsyncSceneLoader.Instance.AsyncLoad(SceneID.GAME));
    }
}
