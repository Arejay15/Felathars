using UnityEngine;
using UnityEngine.InputSystem;

public class BluePowerUp : MonoBehaviour
{

    [SerializeField] GameObject powerUp;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            gamemanager.instance.playerScript.damageReduction += .1f;
            gamemanager.instance.playerReductionBar.gameObject.SetActive(true);
            Destroy(powerUp);
        }
    }
}
