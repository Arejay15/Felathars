using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using Unity.VisualScripting;
public class EnemyAI : MonoBehaviour, IDamage
{

    // Enemy stats
    [Header("Enemy Configuration")]
    [SerializeField] gamemanager.ColorType defensiveColor;

    [Header("Components")]
    [SerializeField] Renderer model;
    [SerializeField] NavMeshAgent agent;

    [Header("Stats")]
    [SerializeField] float HP;
    [Range(1, 10), SerializeField] int faceTargetSpeed;
    

    [Header("Weapon")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gunPivot;
    [SerializeField] Transform shootPos;
    [Range(0.1f, 2f), SerializeField] float shootRate;
    [Range(1, 10), SerializeField] int gunRotateSpeed;

    Color colorOrig;

    Vector3 playerDir;

    bool playerInTrigger;
    float shootTimer;

    float angleToPlayer;

    Transform playerTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        colorOrig = model.material.color;

        gamemanager.instance.updateGameGoal(1);

        playerTransform = gamemanager.instance.player.transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTrigger && canSeePlayer())
        {
            
            agent.SetDestination(gamemanager.instance.player.transform.position);

            faceTarget();
            rotateGun();

            if (shootTimer > shootRate)
            {
                shoot();
            }

        }
    }
    
    bool canSeePlayer()
    {
        if (playerTransform == null)
        
            return false;

        shootTimer += Time.deltaTime;
        playerDir = gamemanager.instance.player.transform.position - transform.position;
        angleToPlayer = Vector3.Angle(playerDir, transform.forward);

        Debug.DrawRay(transform.position, playerDir);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, playerDir, out hit))
        {

            if (hit.collider.CompareTag("Player"))
            {

                return true;

            }

        }

        return false;

    }

    void shoot()
    {
        shootTimer = 0;
        Instantiate(bullet, shootPos.position, gunPivot.rotation);
    }

    void faceTarget()
    {
        Quaternion rot = Quaternion.LookRotation(new Vector3(playerDir.x, 0, playerDir.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, faceTargetSpeed * Time.deltaTime);
    }

    void rotateGun()
    {
        Quaternion rot = Quaternion.LookRotation(playerDir);
        gunPivot.rotation = Quaternion.Lerp(gunPivot.rotation, rot, Time.deltaTime * gunRotateSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }

    public void takeDamage(float amount, gamemanager.ColorType dmgColor)
    {
        HP -= gamemanager.damageCalc(amount, dmgColor, defensiveColor);

        if (HP <= 0)
        {
            gamemanager.instance.updateGameGoal(-1);
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(flashRed());
        }
    }

    IEnumerator flashRed()
    {
        model.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        model.material.color = colorOrig;
    }

}