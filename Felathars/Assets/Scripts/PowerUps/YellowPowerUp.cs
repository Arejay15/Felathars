using UnityEngine;

public class YellowPowerUp : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger) return;

        gamemanager.instance.playerScript.speed += 5;
        Destroy(gameObject);
    }

}
