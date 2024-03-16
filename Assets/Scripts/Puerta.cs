using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//esto es un objeto interactuable por eso hereda de interactorBase
public class Puerta : InteractorBase
{
    public Animator animator;
    public DecagonoSpawner decagono;
    public bool closed = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if(decagono == null)
        {
            if (transform.parent.parent.parent.GetComponent<DecagonoSpawner>() != null)
            {
                decagono = transform.parent.parent.parent.GetComponent<DecagonoSpawner>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    protected override void Interact()
    {
        closed = false;
        if(canInteract) animator.SetTrigger("Open");

        if (decagono != null)
        {
            Quaternion rotacionAbuelo = transform.parent.parent.rotation;

            decagono.InstanceRoom(transform.position, rotacionAbuelo);
        }
    }

    public virtual void close()
    {
        Debug.Log("PUERTA: close");
        closed = true;
        animator.SetTrigger("Close");
        enableInteract(false);
    }
}
