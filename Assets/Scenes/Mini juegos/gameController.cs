using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class gameController : MonoBehaviour
{
    [SerializeField] private Color correctColor = Color.black;
    [SerializeField] private Color incorrectColor = Color.black;
    [SerializeField] private float tiempoEspera= 0.0f;

    private DB dataBases;
    private interaccion_cofre interaccion_Cofre;
    private QuizzUI UI;
    private bool uiInitialized = false;
    public GameObject[] objetosAleatorios; // Lista de prefabs de los objetos a instanciar
    public float offsetDerecha = 2.0f; // Desplazamiento hacia la derecha
    private PlayerMovement PlayerMovement;

    public GameObject posicionObjeto;

    //empieza el juego
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

    //cambar el color dependiendo si es correcta o no, esperar tiempo p/ cambiar a nueva preg
    private IEnumerator CortinaEntrePregs(optionButton opB) 
    {
        if (opB.opciones.correct)
        {
            opB.SetColor(correctColor);    
            yield return new WaitForSeconds(tiempoEspera);

            //instanciamos objetos aleatorios
            InstanciarObjetoAleatorio();
            
            //verificamos que no se sigan instanciando objetos
            interaccion_Cofre.instanciarObejeto = true;

            UI.ReanudarJuego();

        }
        else
        {
            opB.SetColor(incorrectColor);

            // Desactivar la UI después de un tiempo de espera
            if (UI != null)
            {
                UI.ReanudarJuego();

            }

        }

    }

    private void InstanciarObjetoAleatorio()
    {

        // Generar un índice aleatorio dentro del rango de la lista
        int indiceAleatorio = Random.Range(0, objetosAleatorios.Length);

        // Obtener el prefab correspondiente al índice aleatorio
        GameObject objetoAleatorio = objetosAleatorios[indiceAleatorio];

        // Instanciar el objeto en una posición y rotación arbitrarias

        Instantiate(objetoAleatorio, posicionObjeto.transform.position , Quaternion.identity);

        PlayerMovement.camaraOff = false;
    }


    public void ActivarMiniJuego()
    {
        if (!uiInitialized)
        {
            InitializeUI();
        }
    }

}
