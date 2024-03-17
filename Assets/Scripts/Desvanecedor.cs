using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Desvanecedor : MonoBehaviour
{
    public float fadeInDuration = 1f;
    public float displayDuration = 2f;
    public float fadeOutDuration = 2f;

    [SerializeField] private TMP_Text textMesh;
    private float currentTime = 0f;
    private bool isFadingIn = true;
    private bool isFadingOut = false;

    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0f); // Empezar con alfa 0
    }

    void Update()
    {
        if (isFadingIn)
        {
            FadeIn();
        }
        else if (!isFadingOut)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= displayDuration)
            {
                isFadingOut = true;
                currentTime = 0f;
            }
        }
        else if (isFadingOut)
        {
            FadeOut();
        }
    }

    void FadeIn()
    {
        float alpha = Mathf.Lerp(0f, 1f, currentTime / fadeInDuration);
        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, alpha);

        currentTime += Time.deltaTime;

        if (currentTime >= fadeInDuration)
        {
            currentTime = 0f;
            isFadingIn = false;
        }
    }

    void FadeOut()
    {
        float alpha = Mathf.Lerp(1f, 0f, currentTime / fadeOutDuration);
        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, alpha);

        currentTime += Time.deltaTime;

        if (currentTime >= fadeOutDuration)
        {
            Destroy(gameObject); // O puedes desactivar el objeto en lugar de destruirlo si deseas reutilizarlo.
        }
    }
}
