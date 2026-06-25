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
        cursorImage.sprite = upgradeSprite;
        gamemanager.instance.playerScript.fireRateBuff -= 0.5f;
        Destroy(powerUp);
    }
}
