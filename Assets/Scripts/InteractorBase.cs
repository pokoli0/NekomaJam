using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//https://www.youtube.com/watch?v=gPPGnpV1Y1c
public abstract class InteractorBase : MonoBehaviour
{
    [SerializeField] public string promptMessage;
    [SerializeField] public Image image;

    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        //para overridear
    }
}