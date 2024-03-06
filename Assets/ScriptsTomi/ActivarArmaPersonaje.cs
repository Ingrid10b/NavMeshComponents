using UnityEngine;

public class ActivarArmaPersonaje : MonoBehaviour
{
    public CogerArmas cogerArmas;
    public int numeroArma;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            cogerArmas = player.GetComponent<CogerArmas>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cogerArmas.ActivarArmas(numeroArma);
            Destroy(gameObject);
        }
    }
}
