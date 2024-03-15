using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabitacionInicial : MonoBehaviour
{

    public float totalTime = 5f; // Tiempo total de la cuenta atrás en segundos
    private float currentTime; // Tiempo actual de la cuenta atrás
    void Start()
    {
        currentTime = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Resta el tiempo del contador
        currentTime -= Time.deltaTime;

        // Actualiza el texto mostrado
        int seconds = Mathf.RoundToInt(currentTime);
        Debug.Log("Tiempo restante: " + seconds.ToString() + "s");

       
    }
}
