using UnityEngine;

public class CicloDiaNoche : MonoBehaviour
{
    public float minutos;
    public float velocidad = 10f;

    public Light luzSol;

    public bool esDeNoche = false;
    public bool esDeNocheAnterior = false;

    public event System.Action<bool> OnMiVariableChanged;

    void Update()
    {
        minutos += Time.deltaTime * velocidad;

        if (minutos >= 1440)
        {
            minutos = 0;
        }

        float fraccionDelDia = minutos / 1440f;

        if (fraccionDelDia >= 0.45f && fraccionDelDia <= 1f)
        {
            esDeNoche = true;

            if (!esDeNocheAnterior)
            {
                Debug.Log("Noche");
                CambiarMiVariable(esDeNoche);
            }

            esDeNocheAnterior = true;


        }
        else
        {

            esDeNoche = false;

            if (esDeNocheAnterior)
            {
                Debug.Log("Día");
                CambiarMiVariable(esDeNoche);

            }

            esDeNocheAnterior = false;
        }


        if (luzSol != null)
        {
            luzSol.transform.rotation = Quaternion.Euler(360f * fraccionDelDia, 170f, 0);
        }

    }

    public void CambiarMiVariable(bool nuevoValor)

    {

        // Llamar al evento cuando la variable cambie.

        OnMiVariableChanged?.Invoke(nuevoValor);

    }

}