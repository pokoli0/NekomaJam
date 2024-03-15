using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaSalas3001 : MonoBehaviour
{

    [SerializeField]
    private GameObject salaPrefab_;
    
    [SerializeField]
    private GameObject salaInicial_;
    
    [SerializeField]
    private Vector3 rotacionSala;

    [SerializeField]
    Collider doorCollider;

    GameObject sala; //para guardar la sala q se instancie
    Vector3 posPrefab, rotPrefab;
    public 

    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other == doorCollider)
        {
        Quaternion rotacion = Quaternion.Euler(rotacionSala);
            sala = Instantiate(salaPrefab_, salaInicial_.transform.position, salaInicial_.transform.rotation * rotacion);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other == doorCollider)
        {
            Destroy(salaInicial_);
            other.GetComponentInParent<Collider>().enabled = false;
        }
    }
}
