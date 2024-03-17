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
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Interact()
    {
        gameManager = GameManager.Instance;
        Debug.Log("Interactuo puerta"+ gameManager.hasFinished());
        if (canInteract && gameManager.hasFinished())
        {
            animator.SetTrigger("Open");
            enableInteract(false);
        }
    }

    public void close()
    {
        animator.SetTrigger("Close");
        Invoke("afterCloseEvent", 2f);
    }

    public void afterCloseEvent()
    {
        if (habitacionAnterior != null)
        {
            // habitacionAnterior.parent 
            
            Destroy(habitacionAnterior);
        }

    }
    public void setHabitacionAnterior(GameObject habitacion)
    {
        habitacionAnterior = habitacion;
    }
}
