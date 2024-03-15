using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


[System.Serializable]
public class Texto
{
    public int id;
    public string contenido;
}
[System.Serializable]
public class TextContainer
{
    public List<Texto> textos;
}




public class TextManager : MonoBehaviour
{
    [SerializeField]
    private DialogueScript dialogueScript_;

    public TextAsset jsonFile;
    private TextContainer textContainer_;


    // Start is called before the first frame update
    void Start()
    {
        if(jsonFile != null)
        {
            string jsonString = jsonFile.text;
            textContainer_ = JsonUtility.FromJson<TextContainer>(jsonString);

            if(textContainer_ != null  && textContainer_.textos != null) {
                foreach(Texto texto in textContainer_.textos)
                {

                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
