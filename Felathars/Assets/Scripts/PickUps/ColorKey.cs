using UnityEngine;

public class ColoredKeys : MonoBehaviour
{
    [SerializeField] GameObject Key;
    [SerializeField] Door Door;

    private void OnTriggerEnter(Collider other)
    {
        if(other.isTrigger) return;

        if (other.CompareTag("Player"))
        {
            Door.UnlockDoor();
            Destroy(Key);
        }

    }
}
