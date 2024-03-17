using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//esto es un objeto interactuable por eso hereda de interactorBase
public class PuertaHabitaciones : InteractorBase
{
    public Animator animator;
    [SerializeField] public GameObject habitacionAnterior;
    [SerializeField] public GameObject habitacionSiguiente;
    [SerializeField] public GameObject puerta;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Interact()
    {
        Debug.Log("Interactuo puerta");
        if (canInteract) animator.SetTrigger("Open");
    }

    public void close()
    {
        animator.SetTrigger("Close");
        enableInteract(false);
        Invoke("afterCloseEvent", 2f);
    }

    public void afterCloseEvent()
    {
        if (habitacionAnterior != null)
        {
            // habitacionAnterior.parent 
            puerta.transform.SetParent(habitacionSiguiente.transform);
            Destroy(habitacionAnterior);
        }

    }
}
