using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPuerta : InteractorBase
{
    [SerializeField] GameObject puertaYPared; // Referencia al GameObject de la puerta
    [SerializeField] float duration = 1.8f; // Duraci�n del movimiento en segundos
    [SerializeField] int numOfInteracts = 2; // Duraci�n del movimiento en segundos
    [SerializeField] Collider seAcerca; 

    private Vector3 startPosition;
    private Vector3 targetPosition;

    void Start()
    {
        startPosition = puertaYPared.transform.position;
        targetPosition = startPosition + new Vector3(0, 0, -38);
        //GetComponent<PuertaHabitaciones>().enabled = false;
    }


    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
                if (numOfInteracts > 0)
                {
                Debug.Log("tercero");
                    startPosition = puertaYPared.transform.position;
                    targetPosition = startPosition + new Vector3(0, 0, -39);
                    //GetComponent<PuertaHabitaciones>().enabled = false;
                    StartCoroutine(LerpPosition(targetPosition, duration, numOfInteracts));
                    numOfInteracts--;
                }
                else
                {
                    //nada
                }
    }
    IEnumerator LerpPosition(Vector3 targetPosition, float duration, int numOfInteracts)
    {

        float time = 0f;

        while (time < duration)
        {
            puertaYPared.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        // Aseguramos que el objeto est� en la posici�n final exacta
        puertaYPared.transform.position = targetPosition;
        if(numOfInteracts == 1)
        {
            Destroy(puertaYPared);
        }
    }
}

