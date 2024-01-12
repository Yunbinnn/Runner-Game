using System;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public Action action;

    private void Update()
    {
        // Ű �Է��� ������ ���� ���¶��
        if (!Input.anyKey) return;

        if (action != null) action.Invoke();
    }
}