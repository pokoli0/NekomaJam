using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://www.youtube.com/watch?v=gPPGnpV1Y1c
public abstract class InteractorBase : MonoBehaviour
{
    [SerializeField] public string promptMessage;

    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        //para overridear
    }
}
