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

    void Start()
    {
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
                /*  ** TELEFONO ** */
                if (hitInfo.collider.GetComponent<Telefono>() != null)
                {
                    //Todo esto todavia esta por ver
                    hitInfo.collider.GetComponent<Telefono>().BaseInteract();
                    hitInfo.collider.GetComponent<Telefono>().enableInteract(false);
                }

                /*  ** PUERTA ** */
                if (hitInfo.collider.GetComponent<Puerta>() != null)
                {
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
                    hitInfo.collider.GetComponent<PuertaHabitaciones>().BaseInteract();
                }

                /*  ** PUERTA - SOLA ** */
                if (hitInfo.collider.GetComponent<PuertaSola>() != null)
                {
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
        if(other.gameObject.CompareTag("close_door") && other.GetComponentInChildren<PuertaSola>() != null)
        {
            Debug.Log("SOLA - COLISION");

            PuertaSola p = other.GetComponentInChildren<PuertaSola>();
            
            if (p.closed)
            {
                p.enableCross(true);
            }
            p.close();
            
        }
        else if (other.gameObject.CompareTag("close_door") && other.GetComponentInChildren<PuertaHabitaciones>() != null)
        {
            other.GetComponentInChildren<PuertaHabitaciones>().close();
        }

        //Comprobacion ultima porque 
        else if (other.gameObject.CompareTag("close_door") && other.GetComponentInChildren<Puerta>() != null)
        {
            Debug.Log("PUERTA - COLISION");

            if (other.GetComponentInChildren<Puerta>() != null)
            {
                other.GetComponentInChildren<Puerta>().close();
            }
        }
    }
}
