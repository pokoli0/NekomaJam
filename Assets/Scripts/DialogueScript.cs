using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class DialogueScript : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI dialogueText;

    public string[] lines;

    public float textSpeed = 0.1f;
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator WriteLine()
    {
        yield return new WaitForSeconds(2.0f);
    }

}
