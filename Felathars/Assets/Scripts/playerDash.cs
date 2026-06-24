using System.Collections;
using UnityEngine;

public class playerDash : MonoBehaviour
{
    playerController moveScript;

    [SerializeField, Range(5, 30)] public float dashSpeed;
    [SerializeField, Range(0f, 1.0f)] public float dashTime;
    [SerializeField, Range(1.0f, 5.0f)] public float dashCDOrig;
    float dashCooldown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveScript = GetComponent<playerController>();
        dashCooldown = dashCDOrig;
    }

    // Update is called once per frame
    void Update()
    {
        dashCooldown -= Time.deltaTime;
        
        if (Input.GetButton("Jump"))
        {
            if (dashCooldown <= 0)
            {
                StartCoroutine(Dash());
            }
        }
    }

    IEnumerator Dash() {
        float startTime = Time.time;
        while (Time.time < startTime + dashTime) {
            moveScript.controller.Move(moveScript.moveDir * dashSpeed * Time.deltaTime);
            dashCooldown = dashCDOrig;
            yield return null;
        }
    }
}
