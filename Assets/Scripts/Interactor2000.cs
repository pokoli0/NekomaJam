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

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<FirstPersonAIO>().playerCamera;
        if (displayText != null)
        {
            displayText.enabled = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (displayText != null)
            {
                displayText.enabled = true;
            }
            if (hitInfo.collider.GetComponent<Telefono>() != null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //Todo esto todavia esta por ver
                    hitInfo.collider.GetComponent<InteractorBase>().BaseInteract();
                    hitInfo.collider.GetComponent<InteractorBase>().enableInteract(false);
                }
            }

            if (hitInfo.collider.GetComponent<Puerta>() != null)
            {
                //Debug.Log(hitInfo.collider.GetComponent<Puerta>().promptMessage); //pronto lo cambio a fotooo
                                                                                  // Debug.Log("estoy mirando un interactuable")
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hitInfo.collider.GetComponent<InteractorBase>().BaseInteract();
                }
            }
            if (hitInfo.collider.GetComponent<PuertaDesplazable>() != null)
            {
                //Debug.Log(hitInfo.collider.GetComponent<Puerta>().promptMessage); //pronto lo cambio a fotooo
                // Debug.Log("estoy mirando un interactuable")
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hitInfo.collider.GetComponent<InteractorBase>().BaseInteract();
                }
            }
            if(hitInfo.collider.GetComponent<PuertaHabitaciones>() != null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hitInfo.collider.GetComponent<InteractorBase>().BaseInteract();
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
        if (other.gameObject.CompareTag("close_door") && other.GetComponentInChildren<Puerta>() != null)
        {
            other.GetComponentInChildren<Puerta>().close(); 
        }
        else if (other.gameObject.CompareTag("close_door") && other.GetComponentInChildren<PuertaHabitaciones>() != null)
        {
            other.GetComponentInChildren<PuertaHabitaciones>().close();
        }
    }
}
