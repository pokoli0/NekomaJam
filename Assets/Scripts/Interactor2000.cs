using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactor2000 : MonoBehaviour
{
    private Camera cam;

    [SerializeField] float distance = 3.0f;

    [SerializeField] private LayerMask mask; //esta va a ser la 6


    [SerializeField] public TMP_Text displayText; // el "Pulsa E"

    [SerializeField] private AudioClip openDoor;
    [SerializeField] private AudioClip closeDoor;
    private AudioSource playerSource;

    void PlaySound(AudioClip a )
    {
        playerSource.clip = a;
        playerSource.Play();
    }

    void Start()
    {
        playerSource = GetComponent<AudioSource>();
        cam = GetComponent<FirstPersonAIO>().playerCamera;
        if (displayText != null)
        {
            displayText.enabled = false;
        }
        
    }

    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            //Muestra la tecla para interactuar
            if (displayText != null)
            {
                displayText.enabled = true;
            }
            // Tal vez poner click izquierdo 
            if (Input.GetKeyDown(KeyCode.E))
            {
                /*  ** PESTAÑEO  ** */
                if (hitInfo.collider.GetComponent<Blinks>() != null)
                {
                    Debug.Log("Deberia pestañear 2000");
                    hitInfo.collider.GetComponent<Blinks>().BaseInteract();
                    hitInfo.collider.GetComponent<Blinks>().enableInteract(false);
                }
                /*  ** TELEFONO ** */
                if (hitInfo.collider.GetComponent<Telefono>() != null)
                {
                    hitInfo.collider.GetComponent<Telefono>().BaseInteract();
                    hitInfo.collider.GetComponent<Telefono>().enableInteract(false);
                    
                }

                /*  ** PUERTA ** */
                if (hitInfo.collider.GetComponent<Puerta>() != null)
                {
                    PlaySound(openDoor);
                    hitInfo.collider.GetComponent<Puerta>().BaseInteract();
                }

                if (hitInfo.collider.GetComponent<TelefonoDodecagono>() != null)
                {
                    
                    hitInfo.collider.GetComponent<TelefonoDodecagono>().BaseInteract();
                    hitInfo.collider.GetComponent<TelefonoDodecagono>().enableInteract(false);
                }

                /*  ** PUERTA - HABITACIONES ** */
                if (hitInfo.collider.GetComponent<PuertaHabitaciones>() != null)
                {
                    PlaySound(openDoor);
                    hitInfo.collider.GetComponent<PuertaHabitaciones>().BaseInteract();
                }

                /*  ** PUERTA - SOLA ** */
                if (hitInfo.collider.GetComponent<PuertaSola>() != null)
                {
                    PlaySound(openDoor);
                    hitInfo.collider.GetComponent<PuertaSola>().BaseInteract();
                    PuertaSola p = hitInfo.collider.GetComponent<PuertaSola>();
                    if (!p.CanCross())
                    {
                        p.closed = false;
                    }
                    else
                    {
                        //GameManager.Instance.initFlash();
                        p.flashMethod();
                    }
                }
                /*  ** FLASH ** */
                if (hitInfo.collider.GetComponent<FlashInteract>() != null && hitInfo.collider.GetComponent<FlashInteract>().enabled == true)
                {
                    Debug.Log("Intento interactuar puertaFlash");
                    hitInfo.collider.GetComponent<FlashInteract>().BaseInteract();
                }
            }
        }
        else
        {
            if (displayText != null)
            {
                displayText.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sonar_telefono")){
            //Sala normal
            if(other.gameObject.GetComponent<ActivarTelefono>().telefono != null)
            {
                if (!other.gameObject.GetComponent<ActivarTelefono>().telefono.sonando)
                {
                    other.gameObject.GetComponent<ActivarTelefono>().telefono.StartSound();
                    other.enabled = false;
                }
            }
            //Sala dodecagono
            if(other.gameObject.GetComponent<ActivarTelefono>().telefonoDodec != null)
            {
                if (!other.gameObject.GetComponent<ActivarTelefono>().telefonoDodec.sonando)
                {

                    other.gameObject.GetComponent<ActivarTelefono>().telefonoDodec.StartSound();
                    other.enabled = false;
                }
            }
            

        }
        if(other.gameObject.CompareTag("close_door") && other.GetComponentInChildren<PuertaSola>() != null)
        {

            PuertaSola p = other.GetComponentInChildren<PuertaSola>();
            
            if (p.closed)
            {
                p.enableCross(true);
            }
            else
            {
                PlaySound(closeDoor);
            }
            p.close();
            
        }
        else if (other.gameObject.CompareTag("close_door") && other.GetComponentInChildren<PuertaHabitaciones>() != null)
        {
            if(!other.GetComponentInChildren<PuertaHabitaciones>().closed) PlaySound(closeDoor);
            other.GetComponentInChildren<PuertaHabitaciones>().close();
        }

        //Comprobacion ultima porque 
        else if (other.gameObject.CompareTag("close_door") && other.GetComponentInChildren<Puerta>() != null)
        {
            if(!other.GetComponentInChildren<Puerta>().closed) PlaySound(closeDoor);

            if (other.GetComponentInChildren<Puerta>() != null)
            {
                other.GetComponentInChildren<Puerta>().close();
            }
        }
    }
}
