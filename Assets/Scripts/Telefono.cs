using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//esto es un objeto interactuable por eso hereda de interactorBase
public class Telefono : InteractorBase
{

    [SerializeField] private GameObject puerta;
    [SerializeField] private GameObject paredSinPuerta;
    [SerializeField] private GameObject paredConPuerta;
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
        GameManager gM = GameManager.Instance;
        Debug.Log("el telefono hace cosas");
        gM.getTextManager().showDialogo(gM.getHabitacion());
        gM.nextHabitacion();
        //ACCION DE LA PUERTA
        puerta.SetActive(true);
        paredConPuerta.SetActive(true);
        paredSinPuerta.SetActive(false);
    }
}