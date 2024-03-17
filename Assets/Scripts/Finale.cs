using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finale : MonoBehaviour
{

    public float velocidadRotacion = 90f; // Grados por segundo

    private bool rotando = false;
    private float anguloObjetivo = 90f;

    public GameObject scenario;

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si la colisi�n es con el objeto que queremos
        if (collision.gameObject.CompareTag("Player"))
        {
            
            // Iniciar rotaci�n si no est� rotando actualmente
            if (!rotando)
            {
                rotando = true;
                Debug.Log("Iniciando rotaci�n debido a la colisi�n.");
            }
        }
    }

    void Update()
    {
        if (rotando)
        {
            float paso = velocidadRotacion * Time.deltaTime;
            Quaternion rotacionFinal = Quaternion.Euler(anguloObjetivo, scenario.transform.rotation.y, scenario.transform.rotation.z);

            // Rotar suavemente hacia la rotaci�n final
            scenario.transform.rotation = Quaternion.Lerp(scenario.transform.rotation, rotacionFinal, paso);

            // Verificar si se alcanz� el �ngulo objetivo
            if (Quaternion.Angle(scenario.transform.rotation, rotacionFinal) < 1f)
            {
                // Si la diferencia es menor a 1 grado, detener la rotaci�n
                this.gameObject.SetActive(false);
                Debug.Log("Rotaci�n completada.");
            }
        }
    }
}