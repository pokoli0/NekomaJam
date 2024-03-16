using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabitacionInicial : MonoBehaviour
{

    public float totalTime = 5f; // Tiempo total de la cuenta atrás en segundos
    private float currentTime; // Tiempo actual de la cuenta atrás
    [SerializeField] private GameObject mesa;
    [SerializeField] private GameObject puerta;
    [SerializeField] private GameObject paredSinPuerta;
    [SerializeField] private GameObject paredConPuerta;
    Transform mesaTransform;
    MeshRenderer mesaRenderer;
    Collider mesaCollider;
    Transform telefonoTransform;
    MeshRenderer telefonoRenderer;
    Collider telefonoCollider;
    void Start()
    {
        currentTime = totalTime;
        //mesaTransform = transform.Find("mesa");

        //mesaRenderer = mesaTransform.GetComponent<MeshRenderer>();
        //mesaCollider = mesaTransform.GetComponent<Collider>();

        //telefonoTransform = transform.Find("Telefono");
        //telefonoRenderer = mesaTransform.GetComponent<MeshRenderer>();
        //telefonoCollider = mesaTransform.GetComponent<Collider>();
        //mesaRenderer.enabled = false;
        //mesaCollider.enabled = false;
        //telefonoRenderer.enabled = false;
        //telefonoCollider.enabled = false;
        mesa.SetActive(false);
        puerta.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Resta el tiempo del contador
        if (currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
            // Actualiza el texto mostrado
            int seconds = Mathf.RoundToInt(currentTime);
            Debug.Log("Tiempo restante: " + seconds.ToString() + "s");
        } 
        else
        {
            //mesaRenderer.enabled = true;
            //mesaCollider.enabled = true;
            //telefonoRenderer.enabled = true;
            //telefonoCollider.enabled = true;
            mesa.SetActive(true);
            puerta.SetActive(true);
            paredConPuerta.SetActive(true);
            paredSinPuerta.SetActive(false);
        }



    }
}
