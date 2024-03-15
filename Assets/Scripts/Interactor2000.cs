using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor2000 : MonoBehaviour
{
    private Camera cam;

    [SerializeField] float distance = 3.0f;

    [SerializeField] private LayerMask mask; //esta va a ser la 6

    [SerializeField] private TextManager textManager_;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<FirstPersonAIO>().playerCamera;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if(hitInfo.collider.GetComponent<Telefono>() != null)
            {
                Debug.Log(hitInfo.collider.GetComponent<Telefono>().promptMessage); //pronto lo cambio a fotooo
                // Debug.Log("estoy mirando un interactuable");
                
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //Todo esto todavia esta por ver
                    Debug.Log("HABITACION: " + GameManager.Instance.getHabitacion());
                    hitInfo.collider.GetComponent<InteractorBase>().BaseInteract();
                    textManager_.showDialogo(GameManager.Instance.getHabitacion());
                    GameManager.Instance.nextHabitacion();
                }
            }
            if (hitInfo.collider.GetComponent<Puerta>() != null)
            {

            }
        }
    }
}
