using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinks : InteractorBase
{
    [SerializeField] private GameObject effect;
    protected override void Interact()
    {
        Debug.Log("Entro flash");
        GameManager gameManager = GameManager.Instance;
        if (canInteract && gameManager.hasFinished())
        {
            Instantiate(effect, transform);
        }
    }
}
