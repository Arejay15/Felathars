using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using static UnityEngine.Rendering.DebugUI.Table;

public class playerController : MonoBehaviour
{

    [SerializeField] CharacterController controller;
    [SerializeField] GameObject playerModel;
    [SerializeField] public int HP;
    [SerializeField] public int speed;
    [SerializeField] weapons.weaponTypes type;

    public int originalHP;

    public int tempHP;
    public int damageReduction;

    Vector3 moveDir;

    public float lookSens = 30;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalHP = HP;
        tempHP = 0;
        type = weapons.weaponTypes.game;
    }

    // Update is called once per frame
    void Update()
    {
        lookatmouse();

        movement();

        //sprint(); available as an upgrade?
    }

    void movement()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0, Input.GetAxis("Vertical") * Time.deltaTime * speed);
        Debug.DrawRay(playerModel.transform.position, playerModel.transform.forward * 10, Color.red);
    }

    /*
    
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
    */

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
}

































