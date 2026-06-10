using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public List<GameObject> Bulbs = new List<GameObject>();

    void Start()
    {
        foreach (Transform bulb in transform)
        {
            Bulbs.Add(bulb.gameObject);
            bulb.gameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject bulb in Bulbs)
            {
                bulb.SetActive(true);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject bulb in Bulbs)
            {
                bulb.SetActive(false);
            }

        }
    }
}
