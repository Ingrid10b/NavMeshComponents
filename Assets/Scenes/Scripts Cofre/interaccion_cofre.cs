using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaccion_cofre : MonoBehaviour
{
    LayerMask mask;
    public float distancia = 1.5f;
    public GameObject ultimoReconocido = null;
    private PlayerMovement PlayerMovement;

    public bool instanciarObejeto = false;
    void Start()
    {
        mask = LayerMask.GetMask("Deteccion");
        PlayerMovement = FindObjectOfType<PlayerMovement>();
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
                    Destroy(ultimoReconocido);

                }
            }
        }
        else
        {
            deselect();
        }
    }
    void SelectedObject(Transform transform)
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.green;
        ultimoReconocido = transform.gameObject;

    }
    void deselect()
    {
        if(ultimoReconocido)
        {
            ultimoReconocido.GetComponent<Renderer>().material.color = Color.white;
            ultimoReconocido = null;
        }
    }

}
