using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class gameController : MonoBehaviour
{
    [SerializeField] private Color correctColor = Color.black;
    [SerializeField] private Color incorrectColor = Color.black;
    [SerializeField] private float tiempoEspera = 0.0f;

    private DB dataBases;
    private interaccion_cofre interaccion_Cofre;
    private QuizzUI UI;
    private bool uiInitialized = false;
    public GameObject[] objetosAleatorios;
    public float offsetDerecha = 2.0f;
    private PlayerMovement PlayerMovement;

    private GameObject selectedCofre;
    private Vector3 selectedCofrePosition;



    // Método para recibir el cofre seleccionado desde interaccion_cofre
    public void SetSelectedCofre(GameObject cofre)
    {
        selectedCofre = cofre;
    }

    void Start()
    {
        dataBases = GameObject.FindObjectOfType<DB>();
        interaccion_Cofre = FindObjectOfType<interaccion_cofre>();
        PlayerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void InitializeUI()
    {
        UI = GameObject.FindObjectOfType<QuizzUI>();
        if (UI != null)
        {
            uiInitialized = true;
            SiguientePreg();
        }
    }

    //funcion constructora/operadora de la UI
    private void SiguientePreg()
    {
        if (UI != null)
        {
            UI.Constructor(dataBases.preguntasRamdom(), TraerPreg);
        }
    }

    private void TraerPreg(optionButton opB)
    {
        StartCoroutine(CortinaEntrePregs(opB));
    }

    private IEnumerator CortinaEntrePregs(optionButton opB)
    {
        if (opB.opciones.correct)
        {
            opB.SetColor(correctColor);
            UI.Reset();
            dataBases.RestaurarDB();
            SiguientePreg();

            yield return new WaitForSeconds(tiempoEspera);
            InstanciarObjetoAleatorio();
            interaccion_Cofre.instanciarObejeto = true;
            UI.ReanudarJuego();
        }
        else
        {
            opB.SetColor(incorrectColor);
            UI.Reset();
            dataBases.RestaurarDB();
            SiguientePreg();

            yield return new WaitForSeconds(tiempoEspera);
            PlayerMovement.camaraOff = false;
            UI.ReanudarJuego();
        }
    }
    public void SetSelectedCofre(GameObject cofre, Vector3 cofrePosition)
    {
        selectedCofre = cofre;
        selectedCofrePosition = cofrePosition;
    }


    private void InstanciarObjetoAleatorio()
    {
        if (selectedCofre != null)
        {
            int indiceAleatorio = Random.Range(0, objetosAleatorios.Length);
            GameObject objetoAleatorio = objetosAleatorios[indiceAleatorio];
            Instantiate(objetoAleatorio, selectedCofrePosition, Quaternion.identity);
            PlayerMovement.camaraOff = false;
        }
    }
    public void ActivarMiniJuego()
        {
            if (!uiInitialized)
            {
                InitializeUI();
            }
        }
    }
