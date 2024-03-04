using UnityEngine;

public class interaccion_cofre : MonoBehaviour
{
    LayerMask mask;
    public float distancia = 1.5f;
    public GameObject ultimoReconocido = null;
    private PlayerMovement PlayerMovement;
    private gameController GameController; // Agrega una referencia al gameController

    public bool instanciarObejeto = false;

    void Start()
    {
        mask = LayerMask.GetMask("Deteccion");
        PlayerMovement = FindObjectOfType<PlayerMovement>();
        GameController = FindObjectOfType<gameController>(); // Encuentra el gameController
    }

    void SelectedObject(Transform transform)
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.green;
        ultimoReconocido = transform.gameObject;
    }

    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward));
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia, mask))
        {
            SelectedObject(hit.transform);
            if (hit.collider.tag == "Cofre")
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    PlayerMovement.camaraOff = true;
                    hit.collider.transform.GetComponent<Cofre>().activarCofre();
                    GameController.SetSelectedCofre(hit.collider.gameObject, hit.collider.transform.position); // Llama al método en gameController para informar sobre el cofre seleccionado
                    hit.collider.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            deselect();
        }
    }
    void deselect()
    {
        if (ultimoReconocido)
        {
            ultimoReconocido.GetComponent<Renderer>().material.color = Color.white;
            ultimoReconocido = null;
        }
    }
}





