using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaSalas3000 : MonoBehaviour
{

    [SerializeField]
    public GameObject salaPrefab;
    public Transform salaSpawner;

    GameObject sala; //para guardar la sala q se instancie

    // Start is called before the first frame update
    void Start()
    {
        salaSpawner = transform; //el transform de la puerta para pillar su posicion y rotacion

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && sala == null) //cuando se pulse E y no haya sala instanciada
        {
            sala = Instantiate(salaPrefab, salaSpawner.position, salaSpawner.rotation);
        }
    }
}
