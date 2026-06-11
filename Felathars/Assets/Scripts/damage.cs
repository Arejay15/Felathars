using UnityEngine;

public class damage : MonoBehaviour
{

    enum damageTypes { game, film, music, art, writing }
    [SerializeField] damageTypes damageType;
    [SerializeField] Rigidbody rb;

    [SerializeField] float damageAmount;
    [SerializeField] float damageRate;
    [SerializeField] float bulletSpeed;
    [SerializeField] int bulletDestroyTime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = transform.forward * bulletSpeed;
        Destroy(gameObject, bulletDestroyTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger) return;

        IDamage dmg = other.GetComponent<IDamage>();
        damageTypes defType = other.GetComponent<damageTypes>();

        if (dmg != null)
        {
            switch (damageType)
            {
                case damageTypes.game:
                    if (defType == damageTypes.writing)
                    {
                        dmg.takeDamage(damageAmount * 2);
                    }
                    else
                    {
                        dmg.takeDamage(damageAmount);
                    }
                    Destroy(gameObject);
                    break;

                case damageTypes.music:

                    if (defType == damageTypes.film)
                    {
                        dmg.takeDamage(damageAmount * 2);
                    }
                    else if (defType == damageTypes.art)
                    {
                        dmg.takeDamage(damageAmount / 2);
                    }
                    else
                    {
                        dmg.takeDamage(damageAmount);
                    }
                    Destroy(gameObject);
                    break;

                case damageTypes.film:

                    if (defType == damageTypes.art)
                    {
                        dmg.takeDamage(damageAmount * 2);
                    }
                    else if (defType == damageTypes.music)
                    {
                        dmg.takeDamage(damageAmount / 2);
                    }
                    dmg.takeDamage(damageAmount);
                    Destroy(gameObject);
                    break;

                case damageTypes.art:

                    if (defType == damageTypes.music)
                    {
                        dmg.takeDamage(damageAmount * 2);
                    }
                    else if (defType == damageTypes.film)
                    {
                        dmg.takeDamage(damageAmount / 2);
                    }
                    else
                    {
                        dmg.takeDamage(damageAmount);
                    }
                    Destroy(gameObject);
                    break;
                case damageTypes.writing:

                    if (defType == damageTypes.game)
                    {
                        dmg.takeDamage(damageAmount / 4);
                    }
                    else
                    {
                        dmg.takeDamage(damageAmount * 2);
                    }
                    Destroy(gameObject);


                    break;

                default:

                    break;
            }
        }
    }
}
