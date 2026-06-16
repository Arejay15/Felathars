using UnityEngine;

public class YellowPowerUp : MonoBehaviour
{
    [SerializeField] GameObject powerUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger) return;

        gamemanager.instance.playerScript.speed += 5;
        gamemanager.instance.yellowPowerOverlay.SetActive(true);
        Destroy(powerUp);
    }

}
