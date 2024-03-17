using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinks : InteractorBase
{
    [SerializeField] private GameObject effect;
    protected override void Interact()
    {
        Debug.Log("Entro blink");
        if (canInteract)
        {
            Instantiate(effect, transform);
        }
    }
}
