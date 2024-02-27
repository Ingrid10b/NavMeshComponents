using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public float attackCooldown = 2.0f; // Rango de ataque
    public int damage = 10; // Daño causado por el jugador
    public string enemyTag = "Boss"; // Etiqueta del enemigo

    public GameObject Espada;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameObject.FindWithTag("Espada"))
            {
                gameObject.GetComponent<Animator>().SetTrigger("EspadaAccion");   
            }
            Attack();

        }
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