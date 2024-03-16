using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecagonoSpawner : MonoBehaviour
{

    public GameObject decagonoPrefab;
    private float distanciaDesplazamiento = 15.84576f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstanceRoom(Vector3 posicion, Quaternion rotacion)
    {
        Vector3 desplazamientoZ = Quaternion.Euler(0f, rotacion.y, 0f) * Vector3.forward * distanciaDesplazamiento;
        Vector3 posicionDesplazada = transform.position+ desplazamientoZ;

        Instantiate(decagonoPrefab, posicionDesplazada, Quaternion.Euler(0f, rotacion.y+ 36.5f, 0f) );
    }
}
