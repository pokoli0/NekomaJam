using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecagonoSpawner : MonoBehaviour
{

    public GameObject decagonoPrefab;
    public GameObject salaTlfnPrefab;
    private float distanciaDesplazamiento = 15.84576f;
    private float distanciaDesplazamiento2 = 11.29552f;

    [SerializeField] GameObject previousDoor;
    [SerializeField] GameObject previousDoor2;
    private GameObject previousRoom;
    public GameObject salaTelefono;

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    List<GameObject> BuscarObjetosConComponente<T>(int layer) where T : Component
    {
        List<GameObject> objetosEncontrados = new List<GameObject>();

        // Obtener todos los componentes del tipo T (Puerta en este caso)
        T[] componentes = GetComponentsInChildren<T>(true);

        // Agregar los GameObjects que contienen el componente al resultado
        foreach (T componente in componentes)
        {
            componente.gameObject.layer = layer;
        }
        Debug.Log("PUERTAS DESACTIVADAS");
        return objetosEncontrados;
    }

    public void InstanceRoom(Vector3 posicion, Quaternion rotacion, GameObject puerta, bool labuena)
    {
        BuscarObjetosConComponente<Puerta>(0);


        if (!labuena)
        {
            previousDoor.transform.SetParent(null);

            if (salaTelefono != null)
            {
                Destroy(salaTelefono);
            }
            else
            {
                
                Destroy(previousRoom);
                
            }


            Vector3 desplazamientoZ = Quaternion.Euler(0f, rotacion.eulerAngles.y - 180, 0f) * Vector3.forward * distanciaDesplazamiento;
            Vector3 posicionDesplazada = transform.position + desplazamientoZ;
            
            Debug.Log("NUEVA SALA");
            GameObject salaDecagono = Instantiate(decagonoPrefab, posicionDesplazada, Quaternion.Euler(0f, rotacion.eulerAngles.y - 180, 0f));
            salaDecagono.GetComponent<DecagonoSpawner>(). BuscarObjetosConComponente<Puerta>(6);

            salaDecagono.GetComponent<DecagonoSpawner>().previousRoom = this.gameObject;


            salaDecagono.GetComponent<DecagonoSpawner>().previousDoor = puerta.transform.parent.parent.gameObject;
            salaDecagono.GetComponent<DecagonoSpawner>().previousDoor.transform.SetParent(null);
            salaDecagono.GetComponent<DecagonoSpawner>().previousDoor2 = previousDoor;


            Destroy(previousDoor2);
        }

        else
        {
            previousDoor.transform.SetParent(this.gameObject.transform);

            if (salaTelefono != null)
            {
                Destroy(salaTelefono);
            }
            else
            {
                Destroy(previousRoom);
            }


            Vector3 desplazamientoZ = Quaternion.Euler(0f, rotacion.eulerAngles.y - 180, 0f) * Vector3.forward * distanciaDesplazamiento2;
            Vector3 posicionDesplazada = transform.position + desplazamientoZ;
            
            GameObject salaTLF = Instantiate(salaTlfnPrefab, posicionDesplazada, Quaternion.Euler(0f, rotacion.eulerAngles.y, 0f));

            puerta.transform.parent.parent.SetParent(salaTLF.transform);
            salaTLF.GetComponentInChildren<Telefono>().puertaBorrado = puerta.transform.parent.parent.gameObject;
            //Destroy(salaTLF.transform.GetChild(2).gameObject);
            Destroy(previousDoor2);
        }
     
        
    }
}
