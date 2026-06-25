using UnityEngine;
using UnityEngine.UI;

public class WeaponUIController : MonoBehaviour
{
    [Header("Weapon Icons")]
    public GameObject whiteIcon;
    public GameObject redIcon;
    public GameObject greenIcon;
    public GameObject blueIcon;
    public GameObject yellowIcon;

    [Header("Selection Highlights")]
    public GameObject whiteSelected;
    public GameObject redSelected;
    public GameObject greenSelected;
    public GameObject blueSelected;
    public GameObject yellowSelected;

    public void SetWeaponUnlocked(gamemanager.ColorType color, bool unlocked)
    {
        switch (color)
        {
            case gamemanager.ColorType.WHITE:
                whiteIcon.SetActive(unlocked);
                break;

            case gamemanager.ColorType.RED:
                redIcon.SetActive(unlocked);
                break;

            case gamemanager.ColorType.GREEN:
                greenIcon.SetActive(unlocked);
                break;

            case gamemanager.ColorType.BLUE:
                blueIcon.SetActive(unlocked);
                break;

            case gamemanager.ColorType.YELLOW:
                yellowIcon.SetActive(unlocked);
                break;
        }
    }

    public void SetSelectedWeapon(gamemanager.ColorType color)
    {
        whiteSelected.SetActive(false);
        redSelected.SetActive(false);
        greenSelected.SetActive(false);
        blueSelected.SetActive(false);
        yellowSelected.SetActive(false);

        switch (color)
        {
            case gamemanager.ColorType.WHITE:
                whiteSelected.SetActive(true);
                break;

            case gamemanager.ColorType.RED:
                redSelected.SetActive(true);
                break;

            case gamemanager.ColorType.GREEN:
                greenSelected.SetActive(true);
                break;

            case gamemanager.ColorType.BLUE:
                blueSelected.SetActive(true);
                break;

            case gamemanager.ColorType.YELLOW:
                yellowSelected.SetActive(true);
                break;
        }
    }
}