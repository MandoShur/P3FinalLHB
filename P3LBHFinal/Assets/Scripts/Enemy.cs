using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI; 

public class EnemyController : MonoBehaviour
{
    public float detectionRange = 100.0f; 
    public float attackRange = 2.0f; 
    public float attackCooldown = 1.5f; 
    public int maxHealth = 100; 
    public int damage = 20; 
    public Transform[] patrolPoints; 
    public int health = 20;


    private int currentHealth;
    private Transform player;
    private NavMeshAgent agent;
    private int currentPatrolIndex;
    private float attackCooldownTimer;
    private bool isChasing;

    void Start()
    {
        currentHealth = maxHealth;

        // Find the player object with the "Player" tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
            UnityEngine.Debug.Log("Player found and assigned.");
        }
        else
        {
            UnityEngine.Debug.LogError("Player object not found. Make sure the player GameObject is tagged as 'Player'.");
        }

        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            UnityEngine.Debug.LogError("NavMeshAgent component not found on the enemy.");
        }
        else
        {
            UnityEngine.Debug.Log("NavMeshAgent component found and assigned.");
        }

        currentPatrolIndex = 0;
        GoToNextPatrolPoint();
    }

    void Update()
    {
        if (player == null)
        {
            UnityEngine.Debug.LogWarning("Player is not assigned. Skipping Update.");
            return;
        }

        if (agent == null)
        {
            UnityEngine.Debug.LogWarning("NavMeshAgent is not assigned. Skipping Update.");
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRange)
        {
            isChasing = true;
            agent.destination = player.position;

            if (distanceToPlayer < attackRange && attackCooldownTimer <= 0f)
            {
                AttackPlayer();
                attackCooldownTimer = attackCooldown;
            }
        }
        else
        {
            if (isChasing)
            {
                // Stop chasing and return to patrol
                isChasing = true;
                GoToNextPatrolPoint();
            }
        }

        // Patrol logic
        if (!isChasing && agent.remainingDistance < 1f)
        {
            GoToNextPatrolPoint();
        }

        // Reduce the cooldown timer over time
        if (attackCooldownTimer > 0)
        {
            attackCooldownTimer -= Time.deltaTime;
        }
    }

    void GoToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0)
            return;

        agent.destination = patrolPoints[currentPatrolIndex].position;
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }

    void AttackPlayer()
    {
        // Implement your attack logic here (e.g., reduce player's health)
        UnityEngine.Debug.Log("Attacking Player!");
        // Assuming the player has a PlayerHealth component
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // death logic
        UnityEngine.Debug.Log("Enemy died!");
        Destroy(gameObject);
    }

}
