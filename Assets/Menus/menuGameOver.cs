using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Utility;

public class menuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject MenuGameOver;

    private Vida vidaJugador;

    public bool activeMenuGO;

    private void Start()
    {
        vidaJugador = GameObject.FindWithTag("Player").GetComponent<Vida>();
        //if (vidaJugador.gameOver)
        //{
         //   ActivarMenu();
        //}
    }

    private void ActivarMenu()
    {
        Time.timeScale = 0;
        MenuGameOver.SetActive(true);
        Cursor.visible = true;
        // Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
    }
}