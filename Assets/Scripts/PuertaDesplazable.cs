using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaDesplazable : InteractorBase
{
    [SerializeField] GameObject puertaYPared; // Referencia al GameObject de la puerta
    [SerializeField] float duration = 5f; // Duraci�n del movimiento en segundos
    [SerializeField] int numOfInteracts = 2; // Duraci�n del movimiento en segundos
    [SerializeField] Collider seAcerca; // Duraci�n del movimiento en segundos

    private Vector3 startPosition;
    private Vector3 targetPosition;

    //void Start()
    //{
    //    startPosition = puertaYPared.transform.position;
    //    targetPosition = startPosition + new Vector3(0, 0, -20);
    //    //GetComponent<PuertaHabitaciones>().enabled = false;
    //}


    //void Update()
    //{

    //}
    //void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("VA");
    //    // Verifica si el objeto que entró en el collider tiene un componente de tipo Rigidbody
    //    if (other.GetComponent<Rigidbody>() != null)
    //    {
    //        if (other == seAcerca)
    //        {
    //            if (numOfInteracts > 0)
    //            {
    //                startPosition = puertaYPared.transform.position;
    //                targetPosition = startPosition + new Vector3(0, 0, -20);
    //                //GetComponent<PuertaHabitaciones>().enabled = false;
    //                StartCoroutine(LerpPosition(targetPosition, duration));
    //                numOfInteracts--;
    //            }
    //            else
    //            {
    //                //nada
    //            }
    //        }
    //    }
    //}
    ////protected override void Interact()
    ////{
    ////    Debug.Log("Interactuo desplazable");
    ////    if (numOfInteracts > 0)
    ////    {
    ////        GetComponent<PuertaHabitaciones>().enabled = false;
    ////        Debug.Log("Me desplazo" + numOfInteracts);
    ////        startPosition = puertaYPared.transform.position;
    ////        targetPosition = startPosition + new Vector3(0, 0, -20);
    ////        StartCoroutine(LerpPosition(targetPosition, duration));
    ////        numOfInteracts--;
    ////    }
    ////    if (numOfInteracts == 0) {
    ////        GetComponent<PuertaHabitaciones>().enabled = true;
    ////    }

    ////}
    //IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    //{

    //    float time = 0f;

    //    while (time < duration)
    //    {
    //        puertaYPared.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
    //        time += Time.deltaTime;
    //        yield return null;
    //    }

    //    // Aseguramos que el objeto est� en la posici�n final exacta
    //    puertaYPared.transform.position = targetPosition;
    //}
}

