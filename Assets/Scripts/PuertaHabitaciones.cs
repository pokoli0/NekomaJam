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
    public bool firstRoom = false;

    [SerializeField] public Telefono telefono;


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
        GameManager gameManager = GameManager.Instance;
        Debug.Log("Interactuo puerta"+ gameManager.hasFinished());
        if (canInteract && gameManager.hasFinished())
        {
            animator.SetTrigger("Open");
            enableInteract(false);
        }
    }

    public void close()
    {
        GameManager gameManager = GameManager.Instance;
        animator.SetTrigger("Close");
        gameManager.DestroyInOneSecond(habitacionAnterior);
    }

    public void setHabitacionAnterior(GameObject habitacion)
    {
        habitacionAnterior = habitacion;
    }
}
