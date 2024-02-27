using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CicloDiaNoche : MonoBehaviour
{
    public float minutos, grados;
    public float TimeSpeed = 50;
    public Light lunaLight;
    public bool night = false;


    // Declarar un evento que notificará a otros scripts cuando la variable cambie.
    public event System.Action<bool> OnMiVariableChanged;

    void Update()
    {
        minutos += TimeSpeed * Time.deltaTime;
        if (minutos >= 1440)
        {
            minutos = 0;
        }
        grados = minutos / 4;
        this.transform.localEulerAngles = new Vector3(grados, 90f, 0);

        // Determinar si es de noche o de día.
        // bool isNight = grados >= 250 ;
        bool isDay = grados <= 250 && grados > 100;
        //  bool isMorning = grados < 100;

        if (isDay == true)
        {
            night = false;
            CambiarMiVariable(night);
            Debug.Log(night + "Chau");

        }
        else
        {
            night = true;
            CambiarMiVariable(night);
            Debug.Log(night + "ma;ana");

        }
    }

    public void CambiarMiVariable(bool nuevoValor)
    {
        // Llamar al evento cuando la variable cambie.
        if (OnMiVariableChanged != null)
        {
            OnMiVariableChanged(nuevoValor);
        }
    }
}