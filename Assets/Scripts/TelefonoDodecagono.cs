using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//esto es un objeto interactuable por eso hereda de interactorBase
public class TelefonoDodecagono : InteractorBase
{
    [Header("HABITACIONES SETTIGNS")]

    [SerializeField] private GameObject paredSinPuerta;
    [SerializeField] private GameObject paredConPuerta;
    [SerializeField] private GameObject puerta;
    public bool firstRoom = false;

    [Header("AUDIO SETTINGS")]

    [SerializeField] private AudioClip tonoLlamada;
    [SerializeField] private AudioClip colgarSonido;
    public bool sonando = false;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        sonando = false;
        //Inicializas source y reproduces sonido
        source = GetComponent<AudioSource>();

        puerta.SetActive(false);
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
        GameManager gM = GameManager.Instance; puerta.SetActive(true);
        Debug.Log("Interactuo telefono");
        gM.getTextManager().showDialogo(gM.getHabitacion());
        gM.nextHabitacion();
        //ACCION DE LA PUERTA
        paredConPuerta.SetActive(true);
        paredSinPuerta.SetActive(false);
    }
}