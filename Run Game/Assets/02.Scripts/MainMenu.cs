using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Excute()
    {
        StartCoroutine(AsyncSceneLoader.Instance.AsyncLoad(SceneID.GAME));
    }
}
