using UnityEngine;

public class GreenPowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger) return;

        other.GetComponent<playerController>().tempHP += 20;

        Destroy(gameObject);
    }
}
