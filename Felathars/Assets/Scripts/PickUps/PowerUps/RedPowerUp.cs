using UnityEngine;

public class RedPowerUp : MonoBehaviour
{
    [SerializeField] GameObject powerUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger) return;

        playerController player = other.GetComponent<playerController>();

        if (player.HP < player.originalHP)
        {
            player.HP += 20;
            if(player.HP > player.originalHP)
            {
                player.HP = player.originalHP;
            }
        }
        Destroy(powerUp);
    }
}
