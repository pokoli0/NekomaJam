using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//esto es un objeto interactuable por eso hereda de interactorBase
public class Telefono : InteractorBase
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Interact()
    {
        Debug.Log("el telefono hace cosas");
        //ACCION DE LA PUERTA
    }
}