using UnityEngine.UI;
using UnityEngine;
using System;

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

    public void Constructor(opciones opcion, Action<optionButton> callBack)
    {
        text.text = opcion.text;
        button.onClick.RemoveAllListeners();
        button.enabled = true;
        image.color = colorOriginal;

        opciones = opcion;

        button.onClick.AddListener(delegate
        {
            callBack(this);
        });
    }

    public void SetColor(Color color)
    {
        button.enabled = false;
        image.color = color;
    }

    public void Reset()
    {
        text.text = "";
        button.enabled = true;
        image.color = colorOriginal;
        opciones = null;
    }
}
