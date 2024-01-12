using System;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public Action action;

    private void Update()
    {
        // 키 입력이 들어오지 않은 상태라면
        if (!Input.anyKey) return;

        if (action != null) action.Invoke();
    }
}