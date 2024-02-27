using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour
{
    private Quaternion originLocalRotation; // lo que hace quaternion es que guarda la posicion de x y z

    private void Start()
    {
        originLocalRotation = transform.localRotation; //transform.locarotation es la posicion actual de rotacion de la pistola
    }

    void Update()
    {
        updateSway();
    }

    private void updateSway()
    {
        float t_xLookInput = Input.GetAxis("Mouse X"); // se va a guardar el input de cuanto se mueve nuestro usuario en x
        float t_yLookInput = Input.GetAxis("Mouse Y"); // se va a guardar el input de cuanto se mueve nuestro usuario en y
        //Calculate the weapon rotation
        Quaternion t_xAngleAdjustment = Quaternion.AngleAxis(-t_xLookInput * 2f, Vector3.up);
        Quaternion t_yAngleAdjustment = Quaternion.AngleAxis(t_yLookInput * 2f, Vector3.right);
        Quaternion t_targerRotation = originLocalRotation * t_xAngleAdjustment * t_yAngleAdjustment;
        //Rotate towards tarjet rotation 
        transform.localRotation = Quaternion.Lerp(transform.localRotation, t_targerRotation, Time.deltaTime * 10f); //quaternion lerp pasa de una rotacion especifica hacia otra rotacion en un determinado tiempo
    }
}