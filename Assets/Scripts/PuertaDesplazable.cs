using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaDesplazable : InteractorBase
{
    [SerializeField] GameObject puertaYPared; // Referencia al GameObject de la puerta
    [SerializeField] float duration = 5f; // Duración del movimiento en segundos
    [SerializeField] int numOfInteracts = 2; // Duración del movimiento en segundos

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float velocity;

    void Start()
    {
        startPosition = puertaYPared.transform.position;
        targetPosition = startPosition + new Vector3(0, 0, -20);
        this.GetComponentInParent<PuertaHabitaciones>().enabled = false;
    }
    protected override void Interact()
    {
        if (numOfInteracts > 0)
        {
            startPosition = puertaYPared.transform.position;
            targetPosition = startPosition + new Vector3(0, 0, -20);
            StartCoroutine(LerpPosition(targetPosition, duration));
            numOfInteracts--;
        }
        if (numOfInteracts == 0) {
            this.GetComponentInParent<PuertaHabitaciones>().enabled = true;
        }
        
    }
    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0f;

        while (time < duration)
        {
            puertaYPared.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        // Aseguramos que el objeto esté en la posición final exacta
        puertaYPared.transform.position = targetPosition;
    }
}

