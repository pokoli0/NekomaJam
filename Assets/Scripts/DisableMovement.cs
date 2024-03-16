using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMovement : MonoBehaviour
{
    FirstPersonAIO myFirstPersonAIO;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider has a specific tag
        if (other.CompareTag("movent")) //lo siento por el tag XD
        {
            //myFirstPersonAIO.playerCanMove = false; //deshabilitamos el input pero no va bien
            myFirstPersonAIO.walkSpeed = 0; //esto mejor pero luego hay q ponerlo a 4f
        }
        else if (other.CompareTag("move"))
        {
            myFirstPersonAIO.walkSpeed = 4f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        myFirstPersonAIO = GetComponent<FirstPersonAIO>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
