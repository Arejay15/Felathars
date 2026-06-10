using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject Model;
    [SerializeField] public bool Locked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !Locked)
        {
            Model.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Model.SetActive(true);
        }
    }

    public void UnlockDoor()
    {
        Locked = false;
    }

    public void LockDoor()
    {
        Locked = true;
    }

}
