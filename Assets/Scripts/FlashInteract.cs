using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//esto es un objeto interactuable por eso hereda de interactorBase
public class FlashInteract : InteractorBase
{
    private GameManager gameManager;
    [SerializeField] private GameObject habitacionTeleport;
    [SerializeField] private Vector3 posToTeleport;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Interact()
    {
        gameManager = GameManager.Instance;
        if (canInteract && gameManager.hasFinished())
        {
            gameManager.initFlash();
        }
    }
}
