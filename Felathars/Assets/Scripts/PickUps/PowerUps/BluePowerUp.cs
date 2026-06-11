using UnityEngine;
using UnityEngine.InputSystem;

public class BluePowerUp : MonoBehaviour
{

    [SerializeField] GameObject powerUp;
    private void OnTriggerEnter(Collider other)
    {
       if(other.isTrigger) return;

        gamemanager.instance.playerScript.damageReduction += 5;
        Destroy(powerUp);
    }
}
