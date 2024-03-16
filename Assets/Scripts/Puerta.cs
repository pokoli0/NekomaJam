using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//esto es un objeto interactuable por eso hereda de interactorBase
public class Puerta : InteractorBase
{
    public Animator animator;
    public DecagonoSpawner decagono;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
        if (transform.parent.GetComponent<DecagonoSpawner>() != null)
        {
            decagono = transform.parent.GetComponent<DecagonoSpawner>();
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    protected override void Interact()
    {
        if(canInteract) animator.SetTrigger("Open");

        if (decagono != null)
        {
            Quaternion rotacionAbuelo = transform.parent.parent.rotation;

            decagono.InstanceRoom(transform.position, rotacionAbuelo);
        }
    }

    public void close()
    {
        animator.SetTrigger("Close");
        //enableInteract(false);
    }


}
