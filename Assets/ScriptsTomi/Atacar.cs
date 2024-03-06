using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacar : MonoBehaviour
{
    public int danioArma;
    public float cooldown = 1.0f;
    public float ultimoAtaque;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boss") || other.gameObject.CompareTag("Enemy") && !other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("TRIGER");
            if (Time.time - ultimoAtaque >= cooldown)
            {
                other.gameObject.GetComponent<vidaBoss>().RecibirDanio(danioArma);
                ultimoAtaque = Time.time;
            }
        }
    }
}
