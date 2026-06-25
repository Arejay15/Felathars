using System;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Teleporter teleporter;
    [SerializeField] GameObject telePos;
    [SerializeField] GameObject UI;

    bool inTrigger = false;

    private void Start()
    {
        UI.transform.rotation = Quaternion.Euler(0, 0, 0);

    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && inTrigger)
        {
            CharacterController cc =
                gamemanager.instance.player.GetComponent<CharacterController>();

            cc.enabled = false;
            gamemanager.instance.player.transform.position = teleporter.telePos.transform.position;
            cc.enabled = true;

            inTrigger = false;
            UI.SetActive(false);
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (teleporter != null && other.CompareTag("Player"))
        {
            inTrigger = true;
            UI.SetActive(true);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (teleporter != null && other.CompareTag("Player"))
        {
            inTrigger = false;
            UI.SetActive(false);
        }
    }
}
