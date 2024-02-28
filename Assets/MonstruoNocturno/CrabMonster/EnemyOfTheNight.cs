using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOfTheNight : MonoBehaviour
{
    public float attackCooldown = 2.0f; // Rango de ataque
    public int damage = 10; // Daño causado por el jugador
    public string enemyTag = "Enemy"; // Etiqueta del enemigo

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackCooldown);

        foreach (Collider enemyCollider in hitEnemies)
        {
            if (enemyCollider.gameObject.CompareTag(enemyTag))
            {
                vidaBoss enemyHealth = enemyCollider.GetComponent<vidaBoss>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }
            }
        }
    }
}
