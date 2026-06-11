using UnityEngine;

public class GreenPowerUp : MonoBehaviour
{
    [SerializeField] GameObject powerUp;
    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger) return;

        other.GetComponent<playerController>().tempHP += 20;

        Destroy(powerUp);
    }
}
