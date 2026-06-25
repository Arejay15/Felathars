using UnityEngine;

public class GreenPowerUp : MonoBehaviour
{
    [SerializeField] GameObject powerUp;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            other.GetComponent<playerController>().tempHP += 20;
            gamemanager.instance.playerTempHPIndicator.gameObject.SetActive(true);
            gamemanager.instance.updateTempHPIndicator(other.GetComponent<playerController>().tempHP);
            Destroy(powerUp);
        }
    }
}
