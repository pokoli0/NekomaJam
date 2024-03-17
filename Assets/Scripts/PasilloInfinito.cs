using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasilloInfinito : MonoBehaviour
{

    public GameObject jugador;
    public float distanciaMaxima = 5f;
    public float velocidadMovimiento = 5f;
    public float suavizado = 0.8f;

    private Rigidbody rbPlayer;

    public float offsetPuerta = 5;
    public float offssetMultiplier = 0.5f;


    public GameObject puertaFinal;
    public GameObject pasilloPrefab;

    private bool seguirJugador = true;
    private void Start()
    {
        jugador = GameObject.FindWithTag("Player");
        rbPlayer = jugador.GetComponent<Rigidbody>();

        for(int x = 0; x < 6; x++)
        {
            float nuevaPosicionZ = transform.position.z + (1.942371f*x);
            Instantiate(pasilloPrefab, new Vector3(this.transform.position.x, this.transform.position.y, nuevaPosicionZ), Quaternion.identity);
        }
    }
    void Update()
    {
        Vector3 direccionZGlobal = transform.TransformDirection(Vector3.forward);
        float productoPunto = Vector3.Dot(rbPlayer.velocity, direccionZGlobal);


        if (seguirJugador)
        {

            if (productoPunto > 0)
            {
                Debug.Log("El personaje se está moviendo hacia adelante en el espacio global.");
                float nuevaPosicionZ = puertaFinal.transform.position.z + offsetPuerta;
                Vector3 nuevaPosicion = new(puertaFinal.transform.position.x, puertaFinal.transform.position.y, nuevaPosicionZ);
                puertaFinal.transform.position = Vector3.Lerp(puertaFinal.transform.position, nuevaPosicion, suavizado * Time.deltaTime);
            }
            else if (productoPunto < 0)
            {
                //Debug.Log("El personaje se está moviendo hacia atrás en el espacio global.");
                float nuevaPosicionZ = puertaFinal.transform.position.z - offsetPuerta;
                Vector3 nuevaPosicion = new(puertaFinal.transform.position.x, puertaFinal.transform.position.y, nuevaPosicionZ);
                puertaFinal.transform.position = Vector3.Lerp(puertaFinal.transform.position, nuevaPosicion, suavizado * Time.deltaTime);


            }
            else
            {
                Debug.Log("El personaje no se está moviendo en la dirección del eje Z en el espacio global.");
            }

        }
    }
    
   
    
}