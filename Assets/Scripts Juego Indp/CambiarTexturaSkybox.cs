using UnityEngine;

public class CambiarTexturaSkybox : MonoBehaviour
{
    public Material skyboxDay; // Referencia al material del skybox para el día
    public Material skyboxNight; // Referencia al material del skybox para la noche

    private CicloDiaNoche cicloDiaNoche; // Referencia al script CicloDiaNoche

    void Start()
    {
        cicloDiaNoche = GetComponent<CicloDiaNoche>(); // Obteniendo referencia al script CicloDiaNoche
        // Suscribiéndose al evento para saber cuándo cambia entre día y noche
        if (cicloDiaNoche.esDeNoche == true)
        {
            RenderSettings.skybox = skyboxNight; // Cambiar el skybox a la noche
        } else
        {
            RenderSettings.skybox = skyboxDay; // Cambiar el skybox al día 

        }

    }

}
