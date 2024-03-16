using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//esto es un objeto interactuable por eso hereda de interactorBase
public class Puerta : InteractorBase
{
    public Animator animator;

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
        if(canInteract) animator.SetTrigger("Open");
    }

    public void close()
    {
        animator.SetTrigger("Close");
        enableInteract(false);
    }


}
