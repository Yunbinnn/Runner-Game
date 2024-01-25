using UnityEngine;

public class LeftCollider : MonoBehaviour
{
    private bool leftCheck;

    public bool LeftCheck
    {
        get { return leftCheck; }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Vehicle>(out _))
        {
            leftCheck = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Vehicle>(out _))
        {
            leftCheck = false;
        }
    }
}