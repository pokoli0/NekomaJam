using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//https://www.youtube.com/watch?v=gPPGnpV1Y1c
public abstract class InteractorBase : MonoBehaviour
{
    [SerializeField] public string promptMessage;
    protected bool canInteract = true;

    public void BaseInteract()
    {
        if (canInteract)
        {
            Interact();
        }
        
    }

    protected virtual void Interact()
    {
        //para overridear
    }

    public void enableInteract(bool b)
    {
        canInteract = b;
    }
    
}
