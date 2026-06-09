using Unity.VisualScripting;
using UnityEngine;

public class weapons : MonoBehaviour
{
    public enum weaponTypes {game, film, music, art, writing}

    [SerializeField] weaponTypes type;
    [SerializeField] float fireRate;
    [SerializeField] int damage;
    [Range(1,5)][SerializeField] int timeToDestroy;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        type = weaponTypes.game;
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
            dmg.takeDamage(damage);
        }
    }
}
