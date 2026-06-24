using UnityEngine;

public class WhitePowerUp : MonoBehaviour
{
    [SerializeField] GameObject powerUp;

    //when damage is made use this to modify it
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gamemanager.instance.playerScript.shootRate += 10;
            gamemanager.instance.strengthUpOverlay.gameObject.SetActive(true);
            Destroy(powerUp);
        }
    }
}
