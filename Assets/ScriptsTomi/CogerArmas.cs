using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerArmas : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] armas;
    public float tiempoEscudo = 10.0f;
    public bool contarTiempo = false;
    public bool armaActiva = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(contarTiempo)
        {
            tiempoEscudo -= Time.deltaTime;
        }
        if(tiempoEscudo < 0)
        {
            armas[1].SetActive(false);
            contarTiempo = false;
            tiempoEscudo = 10.0f;
        }


        if(Input.GetKeyDown(KeyCode.X))
        {
            if (armaActiva == true)
            {
                DesactivarArmas();
            } else
            {
                ActivarArmas(0);
            }
        }
    }
    public void ActivarArmas(int numero)
    {
       if (numero >= 0 && numero < armas.Length && armas[numero] != null)
    {
        for (int i = 0; i < armas.Length; i++)
        {
            if (armas[i] != null)
            {
                armas[i].SetActive(false);
            }
        }
        
        if (numero == 1)
        {
            contarTiempo = true;
        }
        
        armas[numero].SetActive(true);
        armaActiva = true;

        }
    }

   public void DesactivarArmas()
    {

        for(int i = 0; i < armas.Length; i++)
        {
            armaActiva = false;
            armas[i].SetActive(false);
        }

    }

}
