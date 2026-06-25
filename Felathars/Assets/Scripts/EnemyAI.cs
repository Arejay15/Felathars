using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using Unity.VisualScripting;
public class EnemyAI : MonoBehaviour, IDamage
{

    // Enemy stats
    [Header("Enemy Configuration")]
    [SerializeField] gamemanager.ColorType defensiveColor;
    [SerializeField] private EnemyIndicator indicatorPrefab;
    [SerializeField] public int team = 1;
    [SerializeField] bool debugging = false;
    public int Team => team;

    [Header("Components")]
    [SerializeField] Renderer model;
    [SerializeField] NavMeshAgent agent;

    [Header("Stats")]
    [SerializeField] float HP;
    [Range(1, 10), SerializeField] int faceTargetSpeed; 


    [Header("Weapon")]
    [SerializeField] weapons.Mode mode;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gunPivot;
    [SerializeField] Transform shootPos;
    [Range(0.1f, 2f), SerializeField] float shootRate;
    [Range(1, 10), SerializeField] int gunRotateSpeed;
    [Header("If Burst")]
    [SerializeField, Range(0.05f, 0.5f)] public float burstSpeed = 0.1f;
    [Header("If Burst/Spread")]
    [SerializeField, Range(2, 15)] public int shotNum;
    [Header("If Spread")]
    [SerializeField, Range(5, 45)] public int spreadAngle;

    Color colorOrig;

    Vector3 playerDir;

    bool playerInTrigger;
    float shootTimer;

    float angleToPlayer;

    Transform playerTransform;

    private EnemyIndicator indicator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        colorOrig = model.material.color;

        gamemanager.instance.updateGameGoal(1);

        indicator = Instantiate(indicatorPrefab, GameObject.Find("Canvas").transform);
        indicator.Setup(transform, gamemanager.instance.player.transform);

        playerTransform = gamemanager.instance.player.transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTrigger)
        {

            if (canSeePlayer())
            {
                faceTarget();
                rotateGun();
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

               

                agent.SetDestination(gamemanager.instance.player.transform.position);
                if (shootTimer > shootRate)
                {
                    shoot();
                }
                
                return true;

            }
            else if (debugging)
            {
                Debug.Log(hit.collider.name);
            }

        }

        return false;

    }

    public void shoot()
    {
        shootTimer = 0;
        switch (mode)
        {
            case weapons.Mode.Burst:
                StartCoroutine(burstshot());
                break;
            case weapons.Mode.Spread:

                float gap = spreadAngle / (shotNum - 1);
                float startAngle = -spreadAngle / 2f;

                for (int i = 0; i < shotNum; i++)
                {
                    float angle = startAngle + gap * i;
                    Quaternion rotation = gunPivot.rotation * Quaternion.Euler(0f, angle, 0f);
                    Instantiate(bullet, shootPos.position, rotation);
                }

                break;
            default:

                Instantiate(bullet, shootPos.position, gunPivot.rotation);
                break;
        }
    }

    IEnumerator burstshot()
    {
        Instantiate(bullet, shootPos.position, gunPivot.rotation);
        for (int i = shotNum - 1; i > 0; i--)
        {
            yield return new WaitForSeconds(burstSpeed);
            Instantiate(bullet, shootPos.position, gunPivot.rotation);
        }
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

        if (playerInTrigger)
        {

            agent.SetDestination(gamemanager.instance.player.transform.position);

        }


        HP -= gamemanager.damageCalc(amount, dmgColor, defensiveColor);

        if (HP <= 0)
        {
            gamemanager.instance.updateGameGoal(-1);

            if (indicator != null)
            {
                Destroy(indicator.gameObject);
            }

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