using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//esto es un objeto interactuable por eso hereda de interactorBase
public class Puerta : InteractorBase
{
    public Animator animator;
    public DecagonoSpawner decagono;
    public bool closed = false;

    public bool laBuena = false;

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
        GameManager gameManager = GameManager.Instance;
        closed = false;
        if(canInteract && gameManager.hasFinished()) animator.SetTrigger("Open");

        if (decagono != null)
        {
            Quaternion rotacionAbuelo = transform.parent.parent.rotation;
            Transform posicionAbuelo = transform.parent.parent;
            
            decagono.InstanceRoom(posicionAbuelo.position, rotacionAbuelo, this.gameObject,laBuena);
            
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
