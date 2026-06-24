using System.Collections;
using UnityEngine;

public class playerDash : MonoBehaviour
{
    playerController moveScript;

    [SerializeField] public float dashSpeed;
    [SerializeField] public float dashTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveScript = GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        dash();
    }

    void dash() {
        if (Input.GetButton("Jump")) {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash() {
        float startTime = Time.time;
        while (Time.time < startTime + dashTime) {
            moveScript.controller.Move(moveScript.moveDir * dashSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
