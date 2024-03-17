using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class DialogueScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI dialogueText;

    private string[] lines = new string[0];

    [SerializeField]
    private float textSpeed = 0.1f;

    [SerializeField]
    private float tiempoEntreFrases = 1.0f;

    private int index;

    private bool isWritting = false;
    
    public bool hasFinished = false;

    
    
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            textSpeed = -0.04f;
        }
    }
public void StartDialogue() {
        hasFinished = false;
        isWritting = true;
        StartCoroutine(WriteLine());
}
    /// <summary>
    /// Corrutina que muestra el texto poco a poco
    /// </summary>
    /// <returns>el tiempo de espera entre caracteres</returns>
    IEnumerator WriteLine()
    {
        
            dialogueText.text = string.Empty;
            if (index < lines.Length)
            {
                foreach (char ch in lines[index].ToCharArray())
                {
                    dialogueText.text += ch;
                    yield return new WaitForSeconds(textSpeed);
                }
                yield return new WaitForSeconds(tiempoEntreFrases);
            }

            if (index < lines.Length - 1)
            {
                index++;
                StartDialogue();
            }
            else
            {
                //Reset index 
                dialogueText.text = string.Empty;
                isWritting = false;
                hasFinished = true;
                index = 0;

            }
        
        
    }

    /// <param name="d">array de strings de dialogo</param>
   public void setLines(string[] d)
    {
        lines = d;
    }

    public bool writting() { return isWritting; }
}
