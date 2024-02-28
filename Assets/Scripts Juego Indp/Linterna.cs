using UnityEngine;
using UnityEngine.UI;

public class Linterna : MonoBehaviour
{
    public Light LuzLinterna;
    public Slider sliderBateria;

    [Header("Energia")]
    public float EnergiaActual = 100;
    public float EnergiaMaxima = 100;
    public float VelocidadConsumo = 2f; // Es la velocidad con la que se consume la energia actual
    public float VelocidadRecarga = 1; // Es la velocidad con la que se recarga la bateria (lo que tarda en recargarse)

    void Update()
    {
        // Encender y apagar la linterna
        if (Input.GetButtonDown("Linterna"))
        {
            if (LuzLinterna.enabled == true)
            {
                LuzLinterna.enabled = false;
            }
            else if (LuzLinterna.enabled == false && EnergiaActual > 10)
            {
                LuzLinterna.enabled = true;
            }
        }

        if (LuzLinterna.enabled == true)
        {
            EnergiaActual -= Time.deltaTime * VelocidadConsumo;

            if (EnergiaActual < 0)
            {
                EnergiaActual = 0;
                LuzLinterna.enabled = false;
            }
        }
        else if (LuzLinterna.enabled == false)
        {
            EnergiaActual += Time.deltaTime * VelocidadRecarga;

            if (EnergiaActual > EnergiaMaxima)
            {
                EnergiaActual = EnergiaMaxima;
            }
        }

       // sliderBateria.value = EnergiaActual / EnergiaMaxima;

        // Si el slider llega al extremo opuesto, apaga la linterna
        if (sliderBateria.value <= 0 || sliderBateria.value >= 1)
        {
            LuzLinterna.enabled = false;
        }
    }
}