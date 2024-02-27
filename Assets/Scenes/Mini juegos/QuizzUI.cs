using System.Collections;
using System ;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizzUI : MonoBehaviour
{
    [SerializeField] private Text question;
    [SerializeField] private List<optionButton> buttonList;


    public GameObject miniGameobject;


    //botones
    public void Constructor(preguntas preg, Action<optionButton> callback)
    {
        Debug.Log(preg);
        question.text = preg.text;

        //recorremos la lista de opciones
        for (int i = 0; i < buttonList.Count; i++)
        {
            //contruimos cada boton con cada opcion dependiendo de la pregunta
            buttonList[i].Constructor(preg.opcion[i], callback);
        }
    }

    public void ReanudarJuego()
    {
        miniGameobject.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
}
