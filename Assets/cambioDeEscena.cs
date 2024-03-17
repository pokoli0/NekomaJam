using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class cambioDeEscena : MonoBehaviour
{
    [SerializeField] GameObject fadein;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string nombreDeLaEscenaACargar = "IDK Scene"; // El nombre de la escena que deseas cargar

    // Método para cargar la nueva escena

    public void OnTriggerEnter(Collider other)
    {
        Instantiate(fadein, transform);
        Invoke("CargarEscena",4f);
    }
public void CargarEscena()
    {
        SceneManager.LoadScene(nombreDeLaEscenaACargar);
    }
}

    
