using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    public GameObject miniGame; //asignamos canvaMiniGame
    public gameController controller; // Referencia al gameController

    public void activarCofre()
    {
        miniGame.SetActive(true);
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Notificar al gameController sobre la activación del mini juego
        controller.ActivarMiniJuego();

    }


}
