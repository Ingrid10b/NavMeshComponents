using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.AI;


public class EnemyOfNight : MonoBehaviour
{
    //atacar
    public int damage = 10;
    public float attackCooldown = 2.0f;
    private float lastAttackTime = 0.0f;

    //control animations
    private Animator animator;

    //stop personaje 
    private NavMeshAgent nM;
    public float originalSpeed;
    public float slowTimer;
    public float stopFactor = 0f;

    public GameObject Enemy;

    private Transform player; // Referencia al objeto del jugador.
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        animator = GetComponent<Animator>();

        nM = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform; // Asigna el jugador por etiqueta "Player".
        navMeshAgent = GetComponent<NavMeshAgent>();
        originalSpeed = GetComponent<NavMeshAgent>().speed;
        slowTimer = 0.0f;

    }
    private void Update()
    {

        if (player != null)
        {
            // Sigue al jugador.
            navMeshAgent.SetDestination(player.position);

            if (Vector3.Distance(transform.position, player.position) <= navMeshAgent.stoppingDistance)
            {
                // El enemigo ha alcanzado al jugador, atacar.
                Attack();
            }
            else
            {
                animator.SetTrigger("Walk_Cycle_1");

            }
        }
    }

    public void ApplySlowEffect(float factor)
    {
        float duration = 5.0f;
        GetComponent<NavMeshAgent>().speed = originalSpeed * factor;
        slowTimer = duration;
        StartCoroutine(RestoreSpeedAfterDelay(duration));
    }

    private void Attack()
    {

        if (Time.time - lastAttackTime >= attackCooldown)
        {
            vidaBoss enemyHealth = Enemy.GetComponent<vidaBoss>();

            Vida playerHealth = player.GetComponent<Vida>();
            if (playerHealth != null && !enemyHealth.isDead)
            {

                playerHealth.TakeDamage(damage);
                animator.SetTrigger("Attack_1");
                lastAttackTime = Time.time;
                ApplySlowEffect(stopFactor);
            }
        }
    }

    private IEnumerator RestoreSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        GetComponent<NavMeshAgent>().speed = originalSpeed;
    }
}
