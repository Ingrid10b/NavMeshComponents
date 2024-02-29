using System.Linq; // importa el espacio de nombres System.Linq, que permite utilizar Language Integrated Query (LINQ) en C#, simplificando la manipulación y consulta de datos en colecciones.
using System.Collections.Generic;  // Importa el espacio de nombres System.Collections.Generic, que proporciona interfaces y clases genéricas, como List<T>, Dictionary<T>, etc.
using UnityEngine;  // Importa el espacio de nombres de la API de Unity, que proporciona acceso a las funcionalidades principales del motor Unity.

//FUNCIONAMIENTO
//Administra una lista de preguntas.
//Permite obtener una pregunta aleatoria de la lista y, opcionalmente, eliminarla de la lista.
//Tiene la capacidad de restaurar la lista original de preguntas desde una copia de seguridad.
//Utiliza la serialización para poder editar la lista de preguntas en el editor de Unity.

public class DB : MonoBehaviour
{
    // Declaramos una lista de objetos del tipo 'preguntas' como serializable para poder editarla en el editor de Unity.
    [SerializeField] private List<preguntas> listaPreguntas = null;

    // Declaramos una lista de respaldo para almacenar una copia de seguridad de las preguntas originales.
    private List<preguntas> backup = null;

    // Este método se llama cuando se inicializa el script.
    private void Awake()
    {
        // Copiamos la lista original de preguntas en la lista de respaldo.
        backup = listaPreguntas.ToList();
    }

    // Este método devuelve una pregunta aleatoria de la lista de preguntas y la elimina de la lista si 'remove' es verdadero.
    public preguntas preguntasRamdom()
    {
        // Si la lista de preguntas está vacía, se restaura desde la lista de respaldo.
        if (listaPreguntas.Count == 0)
        {
            RestaurarDB();
        }

        // Generamos un índice aleatorio dentro del rango de la lista de preguntas.
        int index = Random.Range(0, listaPreguntas.Count);

        // Obtenemos la pregunta en el índice generado.
        preguntas q = listaPreguntas[index];

        listaPreguntas.RemoveAt(index);

        listaPreguntas.Remove(q);

        // Devolvemos la pregunta seleccionada.
        return q;
    }

    // Este método restaura la lista de preguntas desde la lista de respaldo.
    public void RestaurarDB()
    {
        listaPreguntas = backup.ToList();
    }
}
