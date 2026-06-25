using UnityEngine;
using UnityEngine.InputSystem;

public class BluePowerUp : MonoBehaviour
{

    [SerializeField] GameObject powerUp;
    private string hexColor = "#3187FF";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            gamemanager.instance.playerScript.damageReduction += 5;
            if (ColorUtility.TryParseHtmlString(hexColor, out Color newColor))
            {
                gamemanager.instance.playerHPBar.color = newColor;
            }
            Destroy(powerUp);
        }
    }
}
