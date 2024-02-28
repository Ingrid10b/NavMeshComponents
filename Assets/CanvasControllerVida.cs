using UnityEngine;
using TMPro;

public class CanvasControllerVida : MonoBehaviour
{
    public static CanvasControllerVida instance;

    // Referencias a los textos en el Canvas
    public TextMeshProUGUI txtVida;

    // Referencias a los objetos de juego que contienen los valores
    public GameObject vidaJugador;

    // Variables para almacenar los valores de vida y linterna
    float vida;

    // Método para mantener una única instancia de CanvasControllerVida
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
    }
}
