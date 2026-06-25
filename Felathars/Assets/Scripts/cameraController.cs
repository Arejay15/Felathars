using UnityEngine;

public class cameraController : MonoBehaviour
{
    [Range(0.1f, 0.2f)][SerializeField] float displacementMult;
    [Range(0f, 50f)][SerializeField] float maxDist;
    GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        offsetCamera();
        
        
    }

    void offsetCamera()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast(camRay, out float hitDist))
        {
            Vector3 mousePos = camRay.GetPoint(hitDist);
            Vector3 playerPos = player.transform.position;

            Vector3 camDisplacement = (mousePos - player.transform.position) * displacementMult;

            camDisplacement = Vector3.ClampMagnitude(camDisplacement, maxDist);

            Vector3 newCamPos = player.transform.position + camDisplacement;
            newCamPos.y = 15f;

            transform.position = newCamPos;
        }
    }
}
