using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HabitacionInicial : MonoBehaviour
{

    public float totalTime = 5f; // Tiempo total de la cuenta atrás en segundos
    private float currentTime; // Tiempo actual de la cuenta atrás
    [SerializeField] private GameObject mesa;
    [SerializeField] private GameObject mesaPrueba;
    [SerializeField] private GameObject puerta;
    [SerializeField] private GameObject paredSinPuerta;
    [SerializeField] private GameObject paredConPuerta;
    public Vector3 posicionPasillo = new Vector3(-1.4380877f, 2.84217088e-16f, 19.9870644f);
    private bool isVisible = false;
    void Start()
    {
        currentTime = totalTime;
    
        mesa.SetActive(false);
        puerta.SetActive(false);
        paredConPuerta.SetActive(false);
        paredSinPuerta.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // Resta el tiempo del contador
        if (currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
        } 
        else
        {
            if(!isVisible && !isMesaVisible())
            {
                mesa.SetActive(true);
                isVisible = true;
            }
            puerta.SetActive(true);
            paredConPuerta.SetActive(true);
            paredSinPuerta.SetActive(false);
        }
    }

    
    bool isMesaVisible()
    {
        Bounds bounds = mesa.GetComponent<Renderer>().bounds;
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        return GeometryUtility.TestPlanesAABB(planes, bounds);
    }
}
