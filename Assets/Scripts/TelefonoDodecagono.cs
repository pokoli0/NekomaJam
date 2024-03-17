using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//esto es un objeto interactuable por eso hereda de interactorBase
public class TelefonoDodecagono : InteractorBase
{

    [SerializeField] private GameObject paredSinPuerta;
    [SerializeField] private GameObject paredConPuerta;
    [SerializeField] private GameObject puerta;
    public bool firstRoom = false;

    private GameManager gM;
    // Start is called before the first frame update
    void Start()
    {

        puerta.SetActive(false);
        gM = GameManager.Instance;
        if (firstRoom)
        {
            paredConPuerta.SetActive(false);
            paredSinPuerta.SetActive(true);
        }
        else
        {
            paredConPuerta.SetActive(true);
            paredSinPuerta.SetActive(false);
        }
    }

    void Update()
    {

    }

    protected override void Interact()
    {
        puerta.SetActive(true);
        Debug.Log("Interactuo telefono");
        gM.getTextManager().showDialogo(gM.getHabitacion());
        gM.nextHabitacion();
        //ACCION DE LA PUERTA
        paredConPuerta.SetActive(true);
        paredSinPuerta.SetActive(false);
    }
}