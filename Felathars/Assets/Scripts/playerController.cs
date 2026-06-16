using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using static UnityEngine.Rendering.DebugUI.Table;

public class playerController : MonoBehaviour, IDamage
{
    [SerializeField] LayerMask ignoreLayer;

    [SerializeField] CharacterController controller;
    [SerializeField] GameObject playerModel;
    [SerializeField] public float HP;
    [SerializeField] public int speed;
    [SerializeField] public int sprintMod;
    [SerializeField] gamemanager.ColorType defensiveColor;
    [SerializeField] weapons.weaponTypes type;
    [SerializeField] public float shootRate;
    [SerializeField] float damageAmount;
    [SerializeField] int shootDist;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootPos;
    [SerializeField] Transform gunPivot;

    public int damageReduction;
    float shootTimer;
    public float originalHP;
    public int tempHP;

    Vector3 moveDir;

    public float lookSens = 30;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalHP = HP;
        tempHP = 0;
        type = weapons.weaponTypes.game;
        updatePlayerUI();
    }

    // Update is called once per frame
    void Update()
    {
        lookatmouse();

        movement();

        sprint(); //available as an upgrade?
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
            speed *= sprintMod;
        }
        else if (Input.GetButtonUp("Sprint"))
        {
            speed /= sprintMod;
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
        HP -= gamemanager.damageCalc(amount, dmgColor, defensiveColor);
        updatePlayerUI();
        StartCoroutine(flashDamage());

        if (HP <= 0)
        {
            // Hey I'm Dead
            gamemanager.instance.youLose();
        }
    }

    public void updatePlayerUI()
    {
        gamemanager.instance.playerHPBar.fillAmount = (float)HP / originalHP;
        gamemanager.instance.playerReductionBar.fillAmount = (float)HP / originalHP;
        gamemanager.instance.playerTempHPBar.fillAmount = (float)tempHP / originalHP;
    }

    void shoot()
    {
        shootTimer = 0;
        Instantiate(bullet, shootPos.position, gunPivot.rotation);
        
    }

    IEnumerator flashDamage()
    {
        gamemanager.instance.playerDamageFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        gamemanager.instance.playerDamageFlash.SetActive(false);
    }
}

































