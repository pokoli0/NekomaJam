using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//esto es un objeto interactuable por eso hereda de interactorBase
public class Telefono : InteractorBase
{
    [Header("HABITACIONES SETTIGNS")]

    [SerializeField] public GameObject siguienteHabitacion;
    [SerializeField] public GameObject siguienteTransicion;
    [SerializeField] public GameObject habitacionActual;
    [SerializeField] private GameObject paredSinPuerta;
    [SerializeField] private GameObject paredConPuerta;
    [SerializeField] private Vector3 posicionHabitacionSiguiente;
    [SerializeField] private Vector3 posicionTransicionSiguiente;
    [SerializeField] private Vector3 rotacionHabitacionSiguiente;
    [SerializeField] private Vector3 rotacionTransicionSiguiente;
    [SerializeField] public GameObject puertaBorrado;
    [SerializeField] private GameObject puertaFlash = null;
    public bool firstRoom = false;
    

    [Header("AUDIO SETTINGS")]

    [SerializeField] private AudioClip tonoLlamada;
    [SerializeField] private AudioClip colgarSonido;
    public bool sonando = false;
    private AudioSource source;

    private GameManager gM;
    // Start is called before the first frame update
    void Start()
    {
        gM = GameManager.Instance;
        sonando = false;
        //Inicializas source y reproduces sonido
        source = GetComponent<AudioSource>();

        if (firstRoom)
        {
            sonando = true;
            StartSound();
            paredConPuerta.SetActive(false);
            paredSinPuerta.SetActive(true);
        }
        else
        {
            paredConPuerta.SetActive(true);
            paredSinPuerta.SetActive(false);
        }
    }
    public void StartSound()
    {
        source.clip = tonoLlamada;
        source.loop = true;
        source.Play();
    }

    public void CogerTel()
    {
        source.Stop();
        sonando = false;
        source.loop = false;
        source.clip = colgarSonido;
        source.Play();
    }

    protected override void Interact()
    {
        CogerTel();
        if (puertaFlash != null) puertaFlash.GetComponent<FlashInteract>().enabled = true;
        if (puertaBorrado != null) DestroyImmediate(puertaBorrado,true);
        Debug.Log("Interactuo telefono");
        gM.getTextManager().showDialogo(gM.getHabitacion());
        gM.nextHabitacion();
        //ACCION DE LA PUERTA
        Vector3 posActual = habitacionActual.transform.position;
        if (siguienteHabitacion != null && siguienteTransicion != null)
        {
            GameObject transicion = Instantiate(siguienteTransicion, habitacionActual.transform.position + posicionTransicionSiguiente, Quaternion.Euler(rotacionTransicionSiguiente));
            transicion.GetComponentInChildren<PuertaHabitaciones>().setHabitacionAnterior(habitacionActual);
            GameObject habitacion = Instantiate(siguienteHabitacion, habitacionActual.transform.position + posicionHabitacionSiguiente, Quaternion.Euler(rotacionHabitacionSiguiente));
            habitacion.GetComponentInChildren<PuertaHabitaciones>().setHabitacionAnterior(transicion);
        }
        else if (siguienteTransicion != null)
        {
            GameObject transicion = Instantiate(siguienteTransicion, habitacionActual.transform.position + posicionTransicionSiguiente, Quaternion.Euler(rotacionTransicionSiguiente));
            transicion.GetComponentInChildren<PuertaHabitaciones>().setHabitacionAnterior(transform.parent.parent.gameObject);
        }
        
        paredConPuerta.SetActive(true);
        paredSinPuerta.SetActive(false);
    }
}