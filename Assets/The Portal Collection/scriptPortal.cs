using UnityEngine; // Incluye las funcionalidades básicas de Unity.
using UnityEngine.SceneManagement; // Incluye funcionalidades para el manejo de escenas.


//FUNCIONALIDAD:
//Este script de Unity detecta cuando un objeto con la etiqueta "Player" entra en el área de colisión del objeto al que está adjunto. Cuando esto sucede, 
//carga la escena "ArenaFinal", lo que indica que el jugador ha alcanzado un punto de transición.
public class scriptPortal : MonoBehaviour
{
    // Método llamado automáticamente cuando un objeto entra en el área de colisión del portal.
    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto que entra tiene la etiqueta "Player".
        if (other.CompareTag("Player"))
        {
            // Carga la escena "ArenaFinal" cuando el jugador entra en el portal.
            SceneManager.LoadScene("ArenaFinal");
        }
    }
}
