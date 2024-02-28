using System;  // Importa el espacio de nombres System
using System.Collections.Generic;  // Importa el espacio de nombres System.Collections.Generic, que proporciona interfaces y clases genéricas, como List<T>, Dictionary<T>, etc.
using UnityEngine;  // Importa el espacio de nombres de la API de Unity, que proporciona acceso a las funcionalidades principales del motor Unity.
using UnityEngine.UI;  // Importa el espacio de nombres de la API de Unity relacionada con la interfaz de usuario, proporciona clases para interactuar con elementos de la interfaz de usuario, como Text, Button, etc.



//FUNCIONAMIENTO
//La clase QuizzUI es responsable de manejar la interfaz de usuario relacionada con el juego de preguntas.
//El método Constructor se utiliza para inicializar la interfaz de usuario con la pregunta y las opciones correspondientes. Recibe como parámetros un objeto de tipo preguntas y un callback de tipo Action<optionButton>, utilizado para manejar la selección de la opción por el usuario.
public class QuizzUI : MonoBehaviour
{
    [SerializeField] private Text question;  // Referencia al objeto Text donde se mostrará la pregunta.
    [SerializeField] private List<optionButton> buttonList;  // Lista de botones de opción para la respuesta.

    public GameObject miniGameobject;  // Referencia al objeto del mini juego.

    // Método para inicializar la interfaz del juego de preguntas.
    public void Constructor(preguntas preg, Action<optionButton> callback)
    {
        Debug.Log(preg);  // Muestra la pregunta en la consola para depuración.
        question.text = preg.text;  // Establece el texto de la pregunta en el objeto Text.

        // Recorre la lista de botones.
        for (int i = 0; i < buttonList.Count; i++)
        {
            // Construye cada botón con cada opción dependiendo de la pregunta.
            buttonList[i].Constructor(preg.opcion[i], callback);
        }
    }

    // Método para reanudar el juego.
    //El método ReanudarJuego se utiliza para reanudar el juego después de haber pausado el mini juego. Desactiva el objeto del mini juego, restaura el tiempo de juego a su valor normal, oculta el cursor y bloquea el cursor dentro de la ventana del juego.
    public void ReanudarJuego()
    {
        // Desactiva el objeto del mini juego.
        miniGameobject.SetActive(false);
        // Restaura el tiempo de juego a su valor normal.
        Time.timeScale = 1f;
        // Oculta el cursor.
        Cursor.visible = false;
        // Bloquea el cursor dentro de la ventana del juego.
        Cursor.lockState = CursorLockMode.Locked;
    }
}
