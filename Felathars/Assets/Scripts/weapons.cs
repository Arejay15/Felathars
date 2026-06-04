using Unity.VisualScripting;
using UnityEngine;

public class weapons : MonoBehaviour
{
    enum weaponTypes {game, film, music, art, writing}

    [SerializeField] weaponTypes type;
    [SerializeField] int fireRate;
    [SerializeField] int damage;
    [Range(0.01f, 100)][SerializeField] float bulletSpeed;
    [Range(1,5)][SerializeField] int timeToDestroy;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
