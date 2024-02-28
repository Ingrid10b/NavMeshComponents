﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Utility;

public class Vida : MonoBehaviour
{
   // public event EventHandler gameOver;
    public GameObject gameOver;

    public GameObject vidaJugador;
    public Slider SliderVida;


    public int maxHealth = 100;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        //SliderVida.value = maxHealth;

    }

    public void TakeDamage(int damage)
    {
        
        currentHealth -= damage;


        SliderVida.value = currentHealth;



        if (currentHealth <= 0) 
        {
            gameOver.SetActive(true);

            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;


        }

    }
}

