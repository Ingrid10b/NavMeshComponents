using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("General")]
    public LayerMask hittableLayers;
    public GameObject bulletHolePrefab;
    public int danio;

    [Header("Shoot Paramaters")]
    public float fireRange = 200;
    public float recoilForce = 4f; //Fuerza de retrocesos del arma

    private Transform cameraPlayerTransform;

    private void Start()
    {
        cameraPlayerTransform = GameObject.FindGameObjectWithTag("MainCamera").transform; //esto sirve para encontrar el medio de la pantalla
    }

    private void Update()
    {
        HandleShoot(); // esta funcion sirve para ver si estamos disparando o no

        transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, Time.deltaTime * 5f);
    }
    private void HandleShoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            AddRecoil();
            RaycastHit hit; // es como un laser el cual podemos controlar la posicion inicial y la direccion del laser en td momento tambien podemos poner que objetos sean afectados por el laser y cuales no
            //raycasthit va a guardar todos los datos una vez que el raycast golpee un objeto
            //lo que le pasa a la funcion physics es la posicion inicial,hacia donde va a ir dirigidaw,donde queremos que se guarde la info,cuanta distancia y que capas quiero q afecte
            //este regresa un bool cada vez que le pega a un objeto
            if (Physics.Raycast(cameraPlayerTransform.position, cameraPlayerTransform.forward, out hit, fireRange, hittableLayers))
            {
                Debug.Log(hit.transform.name);
              //          hit.transform.GetComponent<vidaBoss>().RecibirDanio(danio);
                GameObject bulletHoleClone = Instantiate(bulletHolePrefab, hit.point + hit.normal * 0.001f, Quaternion.LookRotation(hit.normal));
                Destroy(bulletHoleClone, 1f);
            }

        }
    }

    private void AddRecoil()
    {
        transform.Rotate(-recoilForce, 0f, 0f);
        transform.position = transform.position - transform.forward * (recoilForce / 50f);
    }
}