using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizzUI : MonoBehaviour
{
    [SerializeField] private Text question;
    [SerializeField] private List<optionButton> buttonList;
    public GameObject miniGameobject;

    public void Constructor(preguntas preg, Action<optionButton> callback)
    {
        Reset();

        Debug.Log(preg);
        question.text = preg.text;

        for (int i = 0; i < buttonList.Count; i++)
        {
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

    public void Reset()
    {
        question.text = "";

        for (int i = 0; i < buttonList.Count; i++)
        {
            buttonList[i].Reset();
        }
    }
}
