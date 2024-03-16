using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [Header ("Main Settings")]
    public Portal linkedPortal;
    public MeshRenderer screen;

    //private variables
    Camera playerCam;
    Camera portalCam;
    RenderTexture viewTexture;

    private void Awake()
    {
        playerCam = Camera.main;
        portalCam = GetComponentInChildren<Camera>();
    }

    void CreateViewTexture()
    {
        if(viewTexture == null || viewTexture.width != Screen.width ||viewTexture.height != Screen.height)
        {
            if(viewTexture != null)
            {
                viewTexture.Release();
            }
            viewTexture = new RenderTexture(Screen.width, Screen.height, 0);
            //Render the view from the portal camera to the view texture
            portalCam.targetTexture = viewTexture;

            linkedPortal.screen.material.SetTexture("_MainTex", viewTexture);

        } 
    }

    //Se llama justo antes de que playerCam sea renderizada
    public void Render()
    {
        screen.enabled = false;
        CreateViewTexture();

        var m = transform.localToWorldMatrix * linkedPortal.transform.localToWorldMatrix * playerCam.transform.localToWorldMatrix;
        portalCam.transform.SetPositionAndRotation(m.GetColumn(3), m.rotation);

        portalCam.Render();
        screen.enabled = true;
    }
}
