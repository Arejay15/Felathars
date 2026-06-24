using System;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Teleporter teleporter;
    [SerializeField] GameObject telePos;

    private void OnTriggerEnter(Collider other)
    {
        if (teleporter != null && other.CompareTag("Player"))
            other.transform.position = teleporter.telePos.transform.position;
       
    }
    
}
