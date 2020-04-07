using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DialogueTree;

public class NPCDialogue : MonoBehaviour
{
    private Dialogue dia;

    public string DialogueDataFilePath;

    
    // Start is called before the first frame update
    void Start()
    {
        dia = Dialogue.LoadDialogue("Assets/Dialogues/" + DialogueDataFilePath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
