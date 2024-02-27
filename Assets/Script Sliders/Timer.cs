using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider DiaNoche;
    public float TimerDayNight = 35;

    private bool stoptimer;

    private float currentTime; // Nueva variable para llevar un seguimiento del tiempo actual

    void Start()
    {
        ArrancarSlider();
    }

    public void ArrancarSlider()
    {
        stoptimer = false;
        currentTime = TimerDayNight; // Establecer el tiempo actual al valor inicial
        DiaNoche.maxValue = TimerDayNight;
        DiaNoche.value = TimerDayNight;
    }

    void Update()
    {
        if (stoptimer == false)
        {
            currentTime -= Time.deltaTime; // Restar el tiempo transcurrido

            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);

            DiaNoche.value = currentTime;

            if (currentTime <= 0)
            {
                stoptimer = true;
                ArrancarSlider();// Reiniciar el temporizador
            }

        }
    }
}