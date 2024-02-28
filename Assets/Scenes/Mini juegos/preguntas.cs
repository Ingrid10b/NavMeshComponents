using System.Collections.Generic; // Importa la clase List desde el espacio de nombres System.Collections.Generic
using UnityEngine; // Importa las clases de Unity


//FUNCIONAMIENTO: 
// La clase preguntas permite la representación y gestión de preguntas con opciones asociadas al juego. Permite configurar el texto de la pregunta y las opciones para que el usuario pueda elegir una respuesta.
public class preguntas : MonoBehaviour
 //public class preguntas : MonoBehaviour: Declara una clase llamada preguntas que hereda de MonoBehaviour, lo que indica que esta clase está diseñada para ser adjuntada a 
{
    // texto pregunta
    public string text = null; // Declara una variable pública llamada 'text' de tipo string que representa el texto de la pregunta

    // listado de opciones
    public List<opciones> opcion = null; // Declara una variable pública llamada 'opcion' que es una lista de objetos de tipo 'opciones'
}