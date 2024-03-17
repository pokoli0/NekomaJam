using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//esto es un objeto interactuable por eso hereda de interactorBase
public class Telefono : InteractorBase
{

    [SerializeField] private GameObject puerta;
    [SerializeField] private GameObject paredSinPuerta;
    [SerializeField] private GameObject paredConPuerta;

    private GameManager gM;
    // Start is called before the first frame update
    void Start()
    {
        gM = GameManager.Instance;
        if(puerta != null)
        {
            puerta.GetComponent<PuertaHabitaciones>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gM.hasFinished() && (puerta != null))
        {
            puerta.GetComponent<PuertaHabitaciones>().enabled = true;
        }
    }

    protected override void Interact()
    {
        gM.getTextManager().showDialogo(gM.getHabitacion());
        gM.nextHabitacion();
        //ACCION DE LA PUERTA
        puerta.SetActive(true);
        paredConPuerta.SetActive(true);
        paredSinPuerta.SetActive(false);
    }
}