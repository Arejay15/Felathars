using UnityEngine;

public class damage : MonoBehaviour
{

    enum damageTypes { game, film, music, art, writing }
    [SerializeField] damageTypes damageType;
    [SerializeField] Rigidbody rb;

    [SerializeField] int damageAmount;
    [SerializeField] float damageRate;
    [SerializeField] float bulletSpeed;
    [SerializeField] int bulletDestroyTime;

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
        if (other.isTrigger) return;

        IDamage dmg = other.GetComponent<IDamage>();
        if (dmg != null)
        {
            dmg.takeDamage(damageAmount);
        }
    }
}
