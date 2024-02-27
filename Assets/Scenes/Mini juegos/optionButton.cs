using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System;

// 'obligamos' a que tenga un componente button e Image 
[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]

public class optionButton : MonoBehaviour
{
    private Button button; 
    private Image image;
    private Text text;
    private Color colorOriginal = Color.black;

    public opciones opciones { get; set; }

    public void Awake()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        text = transform.GetChild(0).GetComponent<Text>();
        colorOriginal = image.color;
    }

    //con action<> recibimos que el jugador seleciona una opcion
    public void Constructor(opciones opcion, Action<optionButton> callBack) 
    { 
        text.text = opcion.text;
        button.onClick.RemoveAllListeners();    
        button.enabled = true;
        image.color = colorOriginal;

        //guardamos la opcion 
        opciones = opcion;

        //escuchamos cuando se presiona el boton
        button.onClick.AddListener(delegate
            {
                callBack(this);
            });
    }
    public void SetColor (Color color)
    {
        button.enabled = false;
        image.color = color;
    }



    }
