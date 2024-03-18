using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioClip sonidoAColisionar;
    public bool pararTodosLosSonidos = false;

    private List<AudioSource> allAudioSources = new List<AudioSource>();

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            // Verificar si tenemos un AudioClip asignado
            if (sonidoAColisionar != null)
            {
                DetenerTodosLosSonidos();
                // Reproducir el sonido
                AudioSource.PlayClipAtPoint(sonidoAColisionar, transform.position);
                this.GetComponent<BoxCollider>().enabled = false;

            }
            else
            {
                Debug.LogWarning("No se ha asignado un AudioClip para reproducir en la colisión.");
                DetenerTodosLosSonidos();
            }
        }
    }
    public void DetenerTodosLosSonidos()
    {
        if (pararTodosLosSonidos == true)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
            allAudioSources.AddRange(audioSources);

            foreach (AudioSource audioSource in allAudioSources)
            {
                audioSource.Stop();
            }

        }
    }
}
