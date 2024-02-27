using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB : MonoBehaviour
{
    [SerializeField] private List<preguntas> listaPreguntas = null;
    private List<preguntas> backup = null;

    private void Awake()
    {
        backup = listaPreguntas.ToList();
    }

    public preguntas preguntasRamdom(bool remove = true)
    {
        if (listaPreguntas.Count == 0)
        {
            RestaurarDB();
        }

        int index = Random.Range(0, listaPreguntas.Count);

        preguntas q = listaPreguntas[index];
        listaPreguntas.RemoveAt(index);
        return q;
    }


    private void RestaurarDB()
    {
        listaPreguntas = backup.ToList();
        
    }
}
