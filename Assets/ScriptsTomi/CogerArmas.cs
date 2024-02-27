using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerArmas : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] armas;
    public float tiempoEscudo = 10.0f;
    public bool contarTiempo = false;
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
            DesactivarArmas();
        }
    }
    public void ActivarArmas(int numero)
    {
        for(int i = 0; i < armas.Length; i++)
        {
            armas[i].SetActive(false);
        }
        if(numero == 1)
        {
            contarTiempo=true;
        }
        armas[numero].SetActive(true);
    }
    
    public void DesactivarArmas()
    {
        for(int i = 0; i < armas.Length; i++)
        {
            armas[i].SetActive(false);
        }

    }

}
