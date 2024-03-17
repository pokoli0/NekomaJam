using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class CrossDetection : MonoBehaviour
{
    [SerializeField]
    private PuertaSola puerta;

    private void Start()
    { 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<FirstPersonAIO>() != null)
        {
            //Para que si cruza una vez, pero vuelve hacia atras no deje pasar el nivel
            if (!puerta.CanCross())
            {
                puerta.enableCross(true);
            }else puerta.enableCross(false);
            puerta.swapCollider();
        }
    }
}
