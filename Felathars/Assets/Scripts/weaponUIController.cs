using Unity.VisualScripting;
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

    private string whiteColor = "#888888";
    private string redColor = "#FF3C3C";
    private string greenColor = "#52FF4B";
    private string blueColor = "#3187FF";
    private string yellowColor = "#FFFC36";

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

        string selectedColor = whiteColor;

        switch (color)
        {
            case gamemanager.ColorType.WHITE:
                whiteSelected.SetActive(true);
                selectedColor = whiteColor;
                break;

            case gamemanager.ColorType.RED:
                redSelected.SetActive(true);
                selectedColor = redColor;
                break;

            case gamemanager.ColorType.GREEN:
                greenSelected.SetActive(true);
                selectedColor = greenColor;
                break;

            case gamemanager.ColorType.BLUE:
                blueSelected.SetActive(true);
                selectedColor = blueColor;
                break;

            case gamemanager.ColorType.YELLOW:
                yellowSelected.SetActive(true);
                selectedColor = yellowColor;
                break;
        }

        if (UnityEngine.ColorUtility.TryParseHtmlString(selectedColor, out Color cursorColor))
        {
            gamemanager.instance.cursorImage.color = cursorColor;
        }
    }
}