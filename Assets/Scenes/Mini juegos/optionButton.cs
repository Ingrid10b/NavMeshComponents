using UnityEngine.UI; // Importa el espacio de nombres UI de Unity
using UnityEngine; // Importa el espacio de nombres principal de Unity
using System; // Importa el espacio de nombres System

//FUNCIONAMIENTO
//este script proporciona una manera de crear y gestionar botones en Unity, permitiendo configurarlos con texto, opciones y colores diferentes,
//así como ejecutar acciones específicas cuando son seleccionados por el usuario.

// 'obligamos' a que tenga un componente button e Image 
[RequireComponent(typeof(Button))] // Asegura que el GameObject tenga un componente Button adjunto
[RequireComponent(typeof(Image))] // Asegura que el GameObject tenga un componente Image adjunto

public class optionButton : MonoBehaviour // Define la clase optionButton que hereda de MonoBehaviour
{
    private Button button; // Variable para almacenar el componente Button
    private Image image; // Variable para almacenar el componente Image
    private Text text; // Variable para almacenar el componente Text
    private Color colorOriginal = Color.black; // Variable para almacenar el color original

    public opciones opciones { get; set; } // Propiedad pública para acceder y modificar opciones

    // Método que se llama cuando se inicializa el GameObject
    public void Awake()
    {
        button = GetComponent<Button>(); // Obtiene el componente Button del GameObject
        image = GetComponent<Image>(); // Obtiene el componente Image del GameObject
        text = transform.GetChild(0).GetComponent<Text>(); // Obtiene el componente Text del primer hijo del GameObject
        colorOriginal = image.color; // Guarda el color original de la imagen
    }

    // Método para construir el botón con una opción y una función de devolución de llamada
    public void Constructor(opciones opcion, Action<optionButton> callBack)
    {
        text.text = opcion.text; // Establece el texto del botón con el texto de la opción
        button.onClick.RemoveAllListeners(); // Elimina todos los listeners de clics del botón
        button.enabled = true; // Habilita el botón
        image.color = colorOriginal; // Restablece el color de la imagen

        opciones = opcion; // Guarda la opción

        // Añade un listener de clic al botón que llama a la función de devolución de llamada
        button.onClick.AddListener(delegate
        {
            callBack(this);
        });
    }

    // Método para establecer el color del botón
    public void SetColor(Color color)
    {
        button.enabled = false; // Deshabilita el botón
        image.color = color; // Establece el color de la imagen
    }
}
