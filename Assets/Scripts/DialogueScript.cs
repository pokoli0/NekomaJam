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
    
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
           StartDialogue();
        }
    }
private void StartDialogue() {
        StartCoroutine(WriteLine());
}

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
                index = 0;
            
        }
        
        
    }
    public void addLine(string line, int i)
    {
        lines[i] = line;
    }
    public void initLines(int size)
    {
        lines = new string[size];
    }
}
