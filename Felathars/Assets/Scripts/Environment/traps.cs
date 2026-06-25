using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class traps : MonoBehaviour
{
    public enum trapType { mine, stun }
    [SerializeField] trapType trap;
    [SerializeField] float damageAmount;
    [SerializeField] gamemanager.ColorType colorType;
    [SerializeField] float stunTime;

    float damageTimer;
    float stunTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        IDamage dmg = other.GetComponent<IDamage>();

        if (dmg != null)
        {
            dmg.takeDamage(damageAmount, colorType);
            if (trap == trapType.stun)
            {
                gamemanager.instance.playerScript.StartCoroutine(gamemanager.instance.playerScript.stun());
            }

            Destroy(gameObject);
        }
        Destroy(gameObject);
        
    }

    

}
