using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerArmas : MonoBehaviour
{
    public GameObject[] armas;
    public float tiempoEscudo = 10.0f;
    public bool contarTiempo = false;
    public bool armaActiva = false;

    void Update()
    {
        if (contarTiempo)
        {
            tiempoEscudo -= Time.deltaTime;
            if (tiempoEscudo <= 0)
            {
                DesactivarArmas();
                contarTiempo = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (armaActiva)
                DesactivarArmas();
            else
                ActivarArmas(0);
        }
    }

    public void ActivarArmas(int numero)
    {
        if (numero >= 0 && numero < armas.Length && armas[numero] != null)
        {
            for (int i = 0; i < armas.Length; i++)
            {
                if (armas[i] != null)
                    armas[i].SetActive(i == numero);
            }

            if (numero == 1)
                contarTiempo = true;

            armaActiva = true;
        }
    }

    public void DesactivarArmas()
    {
        foreach (GameObject arma in armas)
        {
            if (arma != null)
                arma.SetActive(false);
        }
        armaActiva = false;
    }
}
    