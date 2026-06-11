using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using Unity.VisualScripting;
public class EnemyAI : MonoBehaviour, IDamage
{

    enum EnemyTypes { Grey, Red, Green, Blue, Yellow } // Different types of enemies, which will be set in the inspector
    // Enemy stats
    [Header("Enemy Configuration")]
    [SerializeField] EnemyTypes type;

    [Header("Enemy Stats")] // Stats for each type of enemy, which will be set in the inspector
    [SerializeField] int Health; // Health of the enemy
    [SerializeField] int Damage; // Damage dealt to the player when the enemy attacks
    [SerializeField] float Speed; // How fast the enemy moves
    [SerializeField] float detectRange; // How far the enemy can detect the player
    [Range(1, 10), SerializeField] float faceTarget; // How fast the enemy turns to face the player

    Vector3 playerDir; // Direction from the enemy to the player

    bool playerInTrigger; // Whether the player is within the enemy's detection range

    NavMeshAgent Agent; // Reference used for pathfinding and movement

    Renderer Model; // Reference to the enemy's model renderer

    Color enemyColor; // Color of the enemy

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        enemyColor = type switch // Set the enemy color based on the enemy type using a switch expression
        {
            EnemyTypes.Grey => Color.gray, // Set the enemy color to gray if the enemy type is Grey, etc. for the other enemy types
            EnemyTypes.Red => Color.red,
            EnemyTypes.Green => Color.green,
            EnemyTypes.Blue => Color.blue,
            EnemyTypes.Yellow => Color.yellow,
            _ => Color.white // Set the enemy color to white if the enemy type is not recognized
        };

    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTrigger && canSeePlayer()) // if the player is within the enemy's detection range and the enemy can see the player,
        {
            // Set the enemy's destination to the player's position using the NavMeshAgent

            Agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);

        }
    }

    public void takeDamage(float amount)
    {

    }

    bool canSeePlayer()
    {


        Debug.DrawRay(transform.position, playerDir, Color.red); // Draw a ray from the enemy to the player for debugging purposes

        RaycastHit hit; // Variable to store the information about the raycast hit

        if (Physics.Raycast(transform.position, playerDir, out hit)) // Perform a raycast, and store the hit information in the 'hit' variable
        {

            if (hit.collider.CompareTag("Player") && faceTarget < detectRange) // Check if the raycast hit the player, and if the player is within the enemy's detection range
            {


                Agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);


            }


        }

        return false;

    }




}
