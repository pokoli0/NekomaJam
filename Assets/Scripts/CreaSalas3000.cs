using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaSalas3000 : MonoBehaviour
{

    [SerializeField]
    public GameObject salaPrefab;
    public Transform salaSpawner;

    GameObject sala; //para guardar la sala q se instancie

    public 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && sala == null) 
        { 
            sala = Instantiate(salaPrefab, salaSpawner.position, Quaternion.identity); 
        }
    }
}
