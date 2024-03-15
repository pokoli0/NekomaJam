using UnityEngine;

[System.Serializable]
public class DialogoData
{
    public Dialogo[] dialogos;
}

[System.Serializable]
public class Dialogo
{
    public int id;
    public string[] frases;
}

public class TextManager : MonoBehaviour
{
    [SerializeField]
    private DialogueScript dialogueScript_;

    public TextAsset jsonFile;
    public DialogoData dialogoData;

    void Start()
    {
        try
        {
            dialogoData = JsonUtility.FromJson<DialogoData>(jsonFile.text);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error al leer el JSON: " + e.Message);
        }
    }

    void Update()
    {
    }

    public string[] getLines(int idDialogo)
    {
        foreach (Dialogo dialogo in dialogoData.dialogos)
        {
            if (dialogo.id == idDialogo)
            {
                return dialogo.frases;
            }
        }
        return new string[0];
    }

    public void setDialogo(int idT)
    {
        dialogueScript_.setLines(getLines(idT));
    }

    public void showDialogo(int idT)
    {
        setDialogo(idT);
        dialogueScript_.StartDialogue();
    }

    public bool IsWritting() { return dialogueScript_.writting(); }
}
