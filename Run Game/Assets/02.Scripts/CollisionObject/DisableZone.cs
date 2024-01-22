using UnityEngine;

public class DisableZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Vehicle>(out var vehicle))
        {
            vehicle.gameObject.SetActive(false);
        }
    }
}