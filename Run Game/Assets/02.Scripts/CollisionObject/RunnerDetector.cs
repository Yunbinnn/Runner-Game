using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerDetector : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other != null) Debug.Log(gameObject.name + " detected");
    }
}