using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OTE : MonoBehaviour
{
    public GameObject toEnable;
    public GameObject toDisable;
   
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            toEnable.SetActive(true);
            toDisable.SetActive(false);
        }
    }
}
