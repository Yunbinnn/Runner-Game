using UnityEngine;

public class VehicleDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Vehicle>(out var collision))
        {
            collision.Speed = transform.parent.GetComponent<Vehicle>().Speed;
        }
    }
}
