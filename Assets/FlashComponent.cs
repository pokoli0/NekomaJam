using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashComponent : MonoBehaviour
{
    [SerializeField]
    private Image flashImg_;
    [SerializeField]
    private float tiempoEnBlanco = 1f;
    [SerializeField]
    private float velTransicion = 1f;
    [SerializeField]
    private float tiempoAntesFlash = 1f;

    private Color colorInicial;

    // Start is called before the first frame update
    void Start()
    {
        colorInicial = flashImg_.color;
    }
   
    public void startFlash()
    {
        Invoke("waitToFlash", tiempoAntesFlash);
    }

    void waitToFlash()
    {
        flashImg_.color = Color.white;
        Invoke("startTransition", tiempoEnBlanco);
    }
    void startTransition()
    {
        StartCoroutine(Flash());
    }


    IEnumerator Flash()
    {
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime * velTransicion;
            flashImg_.color = Color.Lerp(Color.white, colorInicial, t);
            yield return null;
        }

        // Asegurarse de que el color final sea exactamente el color inicial
        flashImg_.color = colorInicial;
    }
}
