using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//esto es un objeto interactuable por eso hereda de interactorBase
public class Telefono : InteractorBase
{

    [SerializeField] private GameObject siguienteHabitacion;
    [SerializeField] private GameObject siguienteTransicion;
    [SerializeField] private GameObject habitacionActual;
    [SerializeField] private GameObject paredSinPuerta;
    [SerializeField] private GameObject paredConPuerta;
    [SerializeField] private Vector3 posicionHabitacionSiguiente;
    [SerializeField] private Vector3 posicionTransicionSiguiente;
    [SerializeField] private Vector3 rotacionHabitacionSiguiente;
    [SerializeField] private Vector3 rotacionTransicionSiguiente;
    [SerializeField] private GameObject puertaBorrado;
    public bool firstRoom = false;

    private GameManager gM;
    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        if(puertaBorrado != null) Destroy(puertaBorrado);
        Debug.Log("Interactuo telefono");
        gM.getTextManager().showDialogo(gM.getHabitacion());
        gM.nextHabitacion();
        //ACCION DE LA PUERTA
        Vector3 posActual = habitacionActual.transform.position;
        GameObject transicion = Instantiate(siguienteTransicion, habitacionActual.transform.position + posicionTransicionSiguiente, Quaternion.Euler(rotacionTransicionSiguiente));
        transicion.GetComponentInChildren<PuertaHabitaciones>().setHabitacionAnterior(transform.parent.parent.gameObject);
        GameObject habitacion = Instantiate(siguienteHabitacion, habitacionActual.transform.position + posicionHabitacionSiguiente, Quaternion.Euler(rotacionHabitacionSiguiente));
        habitacion.GetComponentInChildren<PuertaHabitaciones>().setHabitacionAnterior(transicion);
        paredConPuerta.SetActive(true);
        paredSinPuerta.SetActive(false);
    }
}