using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuertaSola : Puerta
{
    private bool canCross = false;

    public bool CanCross() {  return canCross; }

    public void enableCross(bool b)
    {
        canCross = b;
    }
    public override void close()
    {
        
        if (canCross)
        {
            Destroy(this.gameObject.transform.parent.gameObject.transform.parent.gameObject);
            // tp con delay
            // tp a sala y ceguera,

        }
        else {
            Debug.Log("Se deberia de cerrar");
            //Cambia el collider de lado para que no se cierre de nuevo en el mismo 
            swapCollider();
            base.close();
            enableInteract(true); 
        }
    }
    protected override void Interact()
    {
        base.Interact();
        //if (!canCross) base.ResetPuerta();
    }

    public void swapCollider()
    {
        Vector3 v = gameObject.transform.parent.GetComponent<BoxCollider>().center;
        gameObject.transform.parent.GetComponent<BoxCollider>().center.Set(v.x * -1, v.y, v.z * -1);
    }
}
