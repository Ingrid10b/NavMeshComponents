using UnityEngine;
using TMPro;

public class CanvasController : MonoBehaviour
{
    public static CanvasController instance;

    // Referencias a los textos en el Canvas
    public TextMeshProUGUI txtVida;
    public TextMeshProUGUI txtLinterna;

    // Referencias a los objetos de juego que contienen los valores
    public GameObject vidaJugador;
    public GameObject linternaObjeto;

    // Variables para almacenar los valores de vida y linterna
    float vida;
    float linterna;

    // Método para mantener una única instancia de CanvasController
    private void Awake()
    {
        // Verifica si ya hay una instancia, si no, establece esta como la instancia actual
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
    }

    // En cada fotograma
    private void Update()
    {
        // Obtener el componente Vida del objeto de jugador
        Vida Vida = vidaJugador.GetComponent<Vida>();

        // Obtener el valor de vida del componente Vida
        vida = Vida.currentHealth;
        // Mostrar el valor de vida en el texto correspondiente
        txtVida.text = vida.ToString();


        Linterna Linterna = linternaObjeto.GetComponent<Linterna>();

        // Obtener el valor de carga de linterna del componente Linterna y redondearlo
        linterna = Mathf.RoundToInt(Linterna.EnergiaActual);
        // Mostrar el valor de carga de linterna en el texto correspondiente
        txtLinterna.text = linterna.ToString();

    }
}
