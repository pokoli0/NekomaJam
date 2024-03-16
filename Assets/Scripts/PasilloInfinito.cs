using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasilloInfinito : MonoBehaviour
{

    public Transform jugador;
    public float distanciaMaxima = 3f;
    public float velocidadMovimiento = 5f;

    public GameObject puertaFinal;

    private bool seguirJugador = false;
    private void Start()
    {
        jugador = Camera.main.transform;
    }
    void Update()
    {
        // Calcula la distancia entre este objeto y el jugador
        float distanciaZ = Mathf.Abs(transform.position.z - jugador.position.z);


        if (distanciaZ < distanciaMaxima)
        {
            seguirJugador = true;
        }
        else
        {
            seguirJugador = false;
        }

        // Si se debe seguir al jugador, mueve este objeto en el eje Z hacia el jugador
        if (seguirJugador)
        {
            // Calcula la dirección en el eje Z
            float direccionZ = Mathf.Sign(jugador.position.z + puertaFinal.transform.position.z);

            float nuevaPosicionZ = puertaFinal.transform.position.z + direccionZ * velocidadMovimiento * Time.deltaTime;

            Vector3 nuevaPosicion = new Vector3(puertaFinal.transform.position.x, puertaFinal.transform.position.y, nuevaPosicionZ);

            puertaFinal.transform.position = nuevaPosicion;
        }
    }

    
}