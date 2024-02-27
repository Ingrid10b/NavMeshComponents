using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class VidaEnemy : MonoBehaviour
{
    public int maxHealth = 50;
    public bool isDead;
    public int currentHealth;
    private Animator animator;

    private Transform enemy; // Referencia al objeto del jugador.



    private void Start()
    {
        animator = GetComponent<Animator>();
        enemy = GameObject.FindWithTag("Enemy").transform;

    }

    public void TakeDamage(int damage)
    {
        if (isDead == true) return;
        currentHealth -= damage;
        if (currentHealth <= 0) { Death(); }
    }

    void Death()
    {
        isDead = true;
        animator.SetTrigger("Die");
        //Destroy(gameObject);
       
    }
}


