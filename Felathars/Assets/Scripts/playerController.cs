using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI.Table;

public class playerController : MonoBehaviour, IDamage
{
    [SerializeField] LayerMask ignoreLayer;

    [SerializeField] CharacterController controller;
    [SerializeField] GameObject playerModel;
    [SerializeField, Range(25f, 250f)] public float HP;
    [SerializeField, Range(5, 50)] public int speed;
    [SerializeField, Range(1.1f, 3f)] public float sprintMod;
    
    [SerializeField] Transform shootPos;
    [SerializeField] Transform gunPivot;
    [SerializeField] Renderer gunModel;
    [SerializeField, Range(0.1f, 10f)] float switchDelay;
    [Header("Enabled Guns")]
    [SerializeField] weapons whiteGun;
    [SerializeField] weapons redGun;
    [SerializeField] weapons greenGun;
    [SerializeField] weapons blueGun;
    [SerializeField] weapons yellowGun;

    public float fireRateBuff = 1;
    gamemanager.ColorType defensiveColor;
    weapons[] gunList;
    weapons activeGun;
    int activeGunNum;

    public int damageReduction;
    float shootRate;
    float shootTimer;
    public float originalHP;
    public float tempHP;

    Vector3 moveDir;

    int lookSens = 30;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalHP = HP;
        tempHP = 0;
        gunList = new weapons[]{ whiteGun, redGun, greenGun, blueGun, yellowGun };
        for (int i = 0; activeGun == null; i++)
        {
            activeGun = gunList[i];
            activeGunNum = i;
        }
        gunModel.material.color = activeGun.materialColor;

        shootRate = activeGun.fireRate;
        defensiveColor = activeGun.colorType;

        updatePlayerUI();
    }

    // Update is called once per frame
    void Update()
    {
        lookatmouse();

        movement();

        selectGun();

        sprint(); //available as an upgrade?
    }

    void selectGun()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            
            activeGunNum++;
            activeGun = null;
            for (int i = activeGunNum; activeGun == null; i++)
            {
                if (i == 5) { i = 0; }
                activeGun = gunList[i];
                activeGunNum = i;
                
            }
            gunModel.material.color = activeGun.materialColor;
            defensiveColor = activeGun.colorType;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            activeGunNum--;
            activeGun = null;
            for (int i = activeGunNum; activeGun == null; i--)
            {
                if (i == -1) { i = 4; }
                activeGun = gunList[i];
                activeGunNum = i;

            }
            gunModel.material.color = activeGun.materialColor;
            defensiveColor = activeGun.colorType;
        }
    }

    void movement()
    {
        shootTimer += Time.deltaTime;

        moveDir = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        controller.Move(moveDir * speed * Time.deltaTime); 
        Debug.DrawRay(playerModel.transform.position, playerModel.transform.forward * 10, Color.red);

        

        if (Input.GetButton("Fire1") && shootTimer > shootRate)
        {
            shoot();
        }
    }

    
    
    void sprint()
    {
        if (Input.GetButtonDown("Sprint"))
        {
            speed = (int)(speed * sprintMod);
        }
        else if (Input.GetButtonUp("Sprint"))
        {
            speed = (int)(speed / sprintMod);
        }
    }
    

    void lookatmouse()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast(camRay, out float hitDist))
        {
            // Intersection point on the ground
            Vector3 mousePos = camRay.GetPoint(hitDist);
            Vector3 playerPos = playerModel.transform.position;

            Quaternion targetRot = Quaternion.LookRotation(mousePos - playerPos);
            targetRot.x = 0;
            targetRot.z = 0;

            float angle = lookSens * Time.deltaTime;
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, targetRot, angle);
        }
    }

    public void takeDamage(float amount, gamemanager.ColorType dmgColor)
    {
        if(tempHP != 0)
        {
            tempHP -= gamemanager.damageCalc(amount, dmgColor, defensiveColor);
            if (tempHP < 0)
            {
                HP -= tempHP;
                tempHP = 0;
            }
        }
        else
        {
            HP -= gamemanager.damageCalc(amount, dmgColor, defensiveColor);
        }
        updatePlayerUI();
        StartCoroutine(flashDamage());

        if (HP <= 0)
        {
            // Hey I'm Dead
            SceneManager.LoadScene("GameOver");
        }
    }

    public void updatePlayerUI()
    {
        gamemanager.instance.playerHPBar.fillAmount = (float)HP / originalHP;
        gamemanager.instance.playerReductionBar.fillAmount = (float)HP / originalHP;
        gamemanager.instance.playerTempHPBar.fillAmount = (float)tempHP / originalHP;
    }

    public void shoot()
    {
        shootTimer = 0;
        switch (activeGun.mode) {
            case weapons.Mode.Burst:
                burstshot();
                break;
            case weapons.Mode.Spread:

                float gap = activeGun.spreadAngle / (activeGun.shotNum - 1);
                float startAngle = -activeGun.spreadAngle / 2f;

                for (int i = 0; i < activeGun.shotNum; i++)
                {
                    float angle = startAngle + gap * i;
                    Quaternion rotation = gunPivot.rotation * Quaternion.Euler(0f, angle, 0f);
                    Instantiate(activeGun.bullet, shootPos.position, rotation);
                }

                break;
            default:
                
                Instantiate(activeGun.bullet, shootPos.position, gunPivot.rotation);
                break;
        }
    }

    IEnumerator burstshot()
    {
        Instantiate(activeGun.bullet, shootPos.position, gunPivot.rotation);
        for (int i = activeGun.shotNum - 1; i > 0; i--)
        {
            yield return new WaitForSeconds(activeGun.burstSpeed);
            Instantiate(activeGun.bullet, shootPos.position, gunPivot.rotation);
        }
    }

    IEnumerator flashDamage()
    {
        gamemanager.instance.playerDamageFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        gamemanager.instance.playerDamageFlash.SetActive(false);
    }
}

































