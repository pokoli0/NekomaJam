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
    [SerializeField]
    private Color flashColor;

    private Color colorInicial;

    // Start is called before the first frame update
    void Start()
    {
        colorInicial = flashImg_.color;
        flashColor.a = 0;
    }
   /// <summary>
   /// espera tiempoAntesFlash para poner la pantalla del color deseado
   /// </summary>
    public void startFlash()
    {
        Invoke("waitToFlash", tiempoAntesFlash);
    }

    /// <summary>
    /// pone la pantalla del color deseado y espera tiempoEnBlanco
    /// </summary>
    void waitToFlash()
    {
        flashImg_.color = flashColor;
        Invoke("startTransition", tiempoEnBlanco);
    }
    /// <summary>
    /// Inicia la transicion del color completo a transparente (alpha 1 -> 0)
    /// </summary>
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
