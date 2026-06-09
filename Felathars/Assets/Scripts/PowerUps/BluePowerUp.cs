using UnityEngine;

public class BluePowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        Destroy(gameObject);
    }
}
