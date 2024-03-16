using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
//PARA USARLO------------

//Tener una referencia en el script del Oscurecedor y llamar a StartFade()
public class Oscurecedor : MonoBehaviour
{
    [SerializeField] public Animation animacion;
    public KeyCode teclaActivacion = KeyCode.E;

    void Update()
    {
        // Verifica si se presiona la tecla especificada
        if (Input.GetKeyDown(teclaActivacion))
        {
            // Si la animación no está reproduciéndose, la activa
            if (!animacion.isPlaying)
            {
                animacion.Play();
            }
        }
    }
}