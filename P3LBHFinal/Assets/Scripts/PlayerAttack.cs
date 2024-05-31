using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int attackDamage = 10; // amount of damage you do
    public float attackRange = 1.5f; // Range of the attack
    public LayerMask enemyLayer; // Layer for enemy detection

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Check if fire1 is pressed
        {
            UnityEngine.Debug.Log("Attack button pressed");
            Attack();
        }
    }

    void Attack()
    {

        // Detect enemies in range of your attack
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        if (hitEnemies.Length > 0)
        {
            UnityEngine.Debug.Log("Enemies detected: " + hitEnemies.Length);
        }
        else
        {
            UnityEngine.Debug.Log("No enemies detected within attack range");
        }

        // Damage each enemy
        foreach (Collider enemy in hitEnemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                UnityEngine.Debug.Log("Hit enemy: " + enemy.name);
                enemyHealth.TakeDamage(attackDamage);
            }
            else
            {
                UnityEngine.Debug.Log("Enemy does not have a EnemyHealth: " + enemy.name);
            }
        }
    }

    // Visualize the attack range in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
