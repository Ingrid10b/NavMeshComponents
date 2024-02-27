using UnityEngine;

public class Velocidad : MonoBehaviour
{
    public float fuerzaInicial = 10f;
    public float fuerzaDespuesDe5Segundos = 5f;
    private float tiempoTranscurrido = 0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Asegúrate de que el Rigidbody tenga gravedad activada si estás utilizando AddForce
        rb.useGravity = true;
    }

    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        if (tiempoTranscurrido >= 5f)
        {
            AplicarFuerza(fuerzaDespuesDe5Segundos);
        }
        else
        {
            AplicarFuerza(fuerzaInicial);
        }
    }

    void AplicarFuerza(float fuerza)
    {
        // Restringe la velocidad máxima para evitar un movimiento demasiado rápido
        float velocidadMaxima = 5f;

        // Aplica la fuerza en la dirección del eje Z
        rb.AddForce(Vector3.forward * fuerza, ForceMode.Force);

        // Limita la velocidad para que no sea demasiado rápida
        if (rb.velocity.magnitude > velocidadMaxima)
        {
            rb.velocity = rb.velocity.normalized * velocidadMaxima;
        }
    }

    // Esta función se llama cuando el jugador colisiona con otro objeto
    void OnCollisionEnter(Collision collision)
    {
        // Comprueba si la colisión es con un objeto que tenga el tag "apple"
       // if (collision.gameObject.CompareTag("apple"))
       // {
            // Restaura la velocidad inicial
          //  RestaurarVelocidadInicial();
       // }
    }

    void RestaurarVelocidadInicial()
    {
        tiempoTranscurrido = 0f;
        // Puedes reiniciar la velocidad del Rigidbody aquí si es necesario
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
