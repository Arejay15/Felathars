using UnityEngine;
using UnityEngine.UI;

public class WhitePowerUp : MonoBehaviour
{
    [SerializeField] GameObject powerUp;
    [SerializeField] Image cursorImage;
    [SerializeField] Sprite upgradeSprite;

    //when damage is made use this to modify it
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cursorImage.sprite = upgradeSprite;
            gamemanager.instance.playerScript.fireRateBuff -= 0.25f;
            Destroy(powerUp);
        }
    }
}
