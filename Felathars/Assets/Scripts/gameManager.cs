using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class gamemanager : MonoBehaviour
{
    public static gamemanager instance;

    [SerializeField] GameObject menuActive;
    [SerializeField] GameObject menuPause;
    [SerializeField] GameObject menuClear;
    [SerializeField] GameObject menuLose;
    [SerializeField] TMP_Text tempHPText;
    [SerializeField] TMP_Text gameGoalCountText;
    [SerializeField] GameObject customCursor;


    public Image playerHPBar;
    public Image playerTempHPIndicator;
    public Image whiteKey;
    public GameObject playerDamageFlash;
    public WeaponUIController weaponUI;
    public Image cursorImage;

    public bool isPaused;
    public GameObject player;
    public playerController playerScript;

    float timeScaleOrig;

    int gameGoalCount;

    void Awake()
    {
        instance = this;
        timeScaleOrig = Time.timeScale;
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerScript = player.GetComponent<playerController>();
        }
        else return;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuActive == null)
            {
                statePause();
                menuActive = menuPause;
                menuActive.SetActive(true);
            }

            else if (menuActive == menuPause)
            {
                stateUnpause();
            }
        }
    }

    public void statePause()
    {
        isPaused = true;
        customCursor.SetActive(false);
        Time.timeScale = 0;
    }

    public void stateUnpause()
    {
        isPaused = false;
        Time.timeScale = timeScaleOrig;
        menuActive.SetActive(false);
        customCursor.SetActive(true);
        menuActive = null;
    }

    public void updateTempHPIndicator(float tempHP)
    {
        tempHPText.text = tempHP.ToString("F0");

        if(tempHP <= 0)
        {
            playerTempHPIndicator.gameObject.SetActive(false);
        }
    else
        {
            playerTempHPIndicator.gameObject.SetActive(true);
        }
    }

    public void updateGameGoal(int amount)
    {
        gameGoalCount += amount;
        gameGoalCountText.text = gameGoalCount.ToString("F0");

        if (gameGoalCount <= 0)
        {
            // Hey you beat the level
            statePause();
            menuActive = menuClear;
            menuActive.SetActive(true);
            customCursor.SetActive(false);
        }
    }

    public void youLose()
    {
        statePause();
        menuActive = menuLose;
        menuActive.SetActive(true);
        customCursor.SetActive(false);
    }

    public enum ColorType { WHITE, RED, GREEN, BLUE, YELLOW, TRUE }
    public static float damageCalc(float damage, ColorType offense, ColorType defense)
    {
        switch (defense)
        {
            case ColorType.WHITE:
                switch (offense)
                {
                    
                    case ColorType.RED:
                        return (float)(damage * 1.15);
                    case ColorType.GREEN:
                        return (float)(damage * 1.15);
                    case ColorType.BLUE:
                        return (float)(damage * 1.15);
                    case ColorType.YELLOW:
                        return (float)(damage * 0.25);
                    default:
                        return damage;
                }
            case ColorType.RED:
                switch (offense)
                {
                    case ColorType.WHITE:
                        return (float)(damage * 0.75);
                    case ColorType.GREEN:
                        return (float)(damage * 0.5);
                    case ColorType.BLUE:
                        return (float)(damage * 1.5);
                    case ColorType.YELLOW:
                        return (float)(damage * 1.25);
                    default:
                        return damage;
                }
            case ColorType.GREEN:
                switch (offense)
                {
                    case ColorType.WHITE:
                        return (float)(damage * 0.75);
                    case ColorType.BLUE:
                        return (float)(damage * 0.5);
                    case ColorType.RED:
                        return (float)(damage * 1.5);
                    case ColorType.YELLOW:
                        return (float)(damage * 1.25);
                    default:
                        return damage;
                }
            case ColorType.BLUE:
                switch (offense)
                {
                    case ColorType.WHITE:
                        return (float)(damage * 0.75);
                    case ColorType.RED:
                        return (float)(damage * 0.5);
                    case ColorType.GREEN:
                        return (float)(damage * 1.5);
                    case ColorType.YELLOW:
                        return (float)(damage * 1.25);
                    default:
                        return damage;
                }
            case ColorType.YELLOW:
                switch (offense)
                {
                    case ColorType.WHITE:
                        return (float)(damage * 2.0);
                    case ColorType.RED:
                        return (float)(damage * 0.85);
                    case ColorType.GREEN:
                        return (float)(damage * 0.85);
                    case ColorType.BLUE:
                        return (float)(damage * 0.85);
                    default:
                        return damage;
                }
            default:
                return damage;
        }
    }
}
