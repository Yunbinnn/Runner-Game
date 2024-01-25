using UnityEngine;

public class RightCollider : MonoBehaviour
{
    private bool rightCheck;

    public bool RightCheck
    {
        get { return rightCheck; }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Vehicle>(out _))
        {
            rightCheck = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Vehicle>(out _))
        {
            rightCheck = false;
        }
    }
}