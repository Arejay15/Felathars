using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using static UnityEngine.Rendering.DebugUI.Table;

public class playerController : MonoBehaviour
{

    [SerializeField] CharacterController controller;
    [SerializeField] public int HP;
    [SerializeField] public int speed;
    [SerializeField] weapons.weaponTypes type;

    public int originalHP;
    public int tempHP;

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
        moveDir = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        controller.Move(moveDir * speed * Time.deltaTime);
        //controller.Move(playerVel * Time.deltaTime);
        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);

        //Vector3 screenMousePos = Input.mousePosition;
        //Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(screenMousePos);
        //worldMousePos.y = 0f;
        //Vector2 final2DPos = worldMousePos;
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

        /*Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if (groundPlane.Raycast(camRay, out rayLength)){
            Vector3 pointToLook = camRay.GetPoint(rayLength);
            Debug.DrawLine(camRay.origin, pointToLook, Color.yellow);
            Quaternion rot = Quaternion.LookRotation(new Vector3(pointToLook.x, 0, pointToLook.z));
                controller.transform.rotation = Quaternion.Lerp(controller.transform.rotation, rot, 5 * Time.deltaTime);
        */
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast(camRay, out float hitDist))
        {
            // Intersection point on the ground
            Vector3 mousePos = camRay.GetPoint(hitDist);
            Vector3 playerPos = transform.position;

            Quaternion targetRot = Quaternion.LookRotation(mousePos - playerPos);
            targetRot.x = 0;
            targetRot.z = 0;

            float angle = lookSens * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, angle);
        }
    }
}

































