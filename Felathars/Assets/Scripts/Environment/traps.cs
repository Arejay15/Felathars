using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class traps : MonoBehaviour
{
    public enum trapType {mine, stun, smoke, laser}
    [SerializeField] trapType trap;
    [SerializeField] float damageAmount;
    [SerializeField] float damageRate;
    [SerializeField] float HP;
    [SerializeField] gamemanager.ColorType colorType;

    float damageTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(float amount, gamemanager.ColorType dmgColor)
    {
        HP -= amount;

        if(HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
          IDamage dmg = other.GetComponent<IDamage>();

        if(dmg != null)
        {
            dmg.takeDamage(damageAmount, colorType);
            Destroy(gameObject);
        }
    }
}
