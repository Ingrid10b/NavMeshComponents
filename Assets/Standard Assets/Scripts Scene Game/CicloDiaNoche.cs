using UnityEngine;

public class CicloDiaNoche : MonoBehaviour
{
    // Variables públicas para ajustar el tiempo en minutos y la velocidad del ciclo día-noche
    public float minutos;
    public float velocidad = 10f;

    // Referencia a la luz del sol en la escena
    public Light luzSol;

    // Variables para controlar si es de noche y si era de noche en el ciclo anterior
    public bool esDeNoche = false;
    public bool esDeNocheAnterior = false;

    // Evento que se dispara cuando la variable de noche cambia
    public event System.Action<bool> OnMiVariableChanged;

    void Update()
    {
        // Aumentar los minutos basados en el tiempo transcurrido y la velocidad
        minutos += Time.deltaTime * velocidad;

        // Reiniciar el ciclo de minutos si alcanza el final del día (1440 minutos en un día)
        if (minutos >= 1440)
        {
            minutos = 0;
        }

        // Calcular la fracción del día actual
        float fraccionDelDia = minutos / 1440f;

        // Determinar si es de noche o de día basado en la fracción del día
        if (fraccionDelDia >= 0.50f && fraccionDelDia <= 1f)
        {
            // Es de noche
            esDeNoche = true;

            // Si no era de noche en el ciclo anterior, dispara el evento y muestra un mensaje de noche
            if (!esDeNocheAnterior)
            {
                Debug.Log("Noche");
                CambiarMiVariable(esDeNoche);
            }

            // Actualizar el estado de noche anterior
            esDeNocheAnterior = true;
        }
        else
        {
            // Es de día
            esDeNoche = false;

            // Si era de noche en el ciclo anterior, dispara el evento y muestra un mensaje de día
            if (esDeNocheAnterior)
            {
                Debug.Log("Día");
                CambiarMiVariable(esDeNoche);
            }

            // Actualizar el estado de noche anterior
            esDeNocheAnterior = false;
        }

        // Si hay una referencia a la luz del sol, ajustar su rotación basada en la fracción del día
        if (luzSol != null)
        {
            luzSol.transform.rotation = Quaternion.Euler(360f * fraccionDelDia, 170f, 0);
        }
    }

    // Método para cambiar la variable de noche y disparar el evento
    public void CambiarMiVariable(bool nuevoValor)
    {
        // Llamar al evento cuando la variable cambie
        OnMiVariableChanged?.Invoke(nuevoValor);
    }
}
