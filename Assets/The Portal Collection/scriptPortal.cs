using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptPortal : MonoBehaviour
{
    //public Transform destination; // El transform del portal de destino (PortalB)

    //cuando el player choque con el trigger se carga otra escena.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // TeleportPlayer(other.transform);
            SceneManager.LoadScene("ArenaFinal");
        }
    }

    // private void TeleportPlayer(Transform player)
    //{
    //  player.position = destination.position;
    // Puedes ajustar la rotación u otras propiedades según tus necesidades
    // }
}