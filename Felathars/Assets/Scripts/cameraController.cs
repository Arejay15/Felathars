using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 9, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
