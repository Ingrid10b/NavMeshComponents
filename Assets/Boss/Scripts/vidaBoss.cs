using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class vidaBoss : MonoBehaviour
{
    public bool isDead = false;
    public int currentHealth;
    private Animator animator;
    public GameObject Enemigo;
    public bool Crab;
    public int vida = 50;


    private void Start()
    {
        animator = GetComponent<Animator>();


    }

    public void RecibirDanio(int valor)
    {
        vida -= valor;
        if (vida <= 0)
        {
            Death();
        }
    }

    public void TakeDamage(int damage)
    {
    if (isDead == true) return;
        currentHealth -= damage;    
    if (currentHealth <= 0 ){Death();}
    }

    void Death()
    {
        isDead = true;
        if (Crab)
        {
            animator.SetTrigger("Die");
            Destroy(gameObject, 2);

        }else 
        {
            animator.SetTrigger("death");
            Destroy(gameObject, 2);

        }

    }


}


