using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Linterna : MonoBehaviour
{
    public Light LuzLinterna;

    [Header("Energia")]
    public float EnergiaActual = 100;
    public float EnergiaMaxima = 100;
    public float VelocidadConsumo = 2f; //Es la velocidad con la que se consume la energia actual
    public float VelocidadRecarga = 1; //Es la velocidad con la que se recarga la bateria (lo que tarda en recargarse)

    [Header("Interfaz")]
    public Image BarraBateria;


    void Update()

    {

        //encender y apagar la linterna
        if (Input.GetButtonDown("Linterna")) // letra para encender o apagar
        {
            // si la linterna esta encendida con la letra c se apaga y viceversa
            if (LuzLinterna.enabled == true)
            {
                LuzLinterna.enabled = false;
            }
            else if (LuzLinterna.enabled == false && EnergiaActual > 10) //EnergiaActual > 10 sirve para que la linterna se pueda encender cuando la energia actual se recargue a 10 antes no se puede encender
            {
                LuzLinterna.enabled = true;

            }
        }

        if (LuzLinterna.enabled == true)

        {
            EnergiaActual -= Time.deltaTime * VelocidadConsumo; //la energia actual disminuye 1sgdos*2sgdos de consumo

            if (EnergiaActual < 0) //cuando llega a 0 se apaga
            {
                EnergiaActual = 0; //limite de energia
                LuzLinterna.enabled = false;
            }
        }
        else if (LuzLinterna.enabled == false)

        {
            EnergiaActual += Time.deltaTime * VelocidadRecarga; // la energia se recarga por segundo

            if (EnergiaActual > EnergiaMaxima)
            {
                EnergiaActual = EnergiaMaxima; // limite de recarga
            }
        }


        BarraBateria.fillAmount = EnergiaActual / EnergiaMaxima;

    }
}