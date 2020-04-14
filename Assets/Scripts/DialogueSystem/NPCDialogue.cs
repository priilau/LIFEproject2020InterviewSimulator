using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DialogueTree;
using System;

public class NPCDialogue : MonoBehaviour
{
    private Dialogue dia;

    private GameObject npcSpeechBubble;
    private GameObject npcText;
    private GameObject npcThoughtsBubble;
    private GameObject npcThoughtsText;
    private GameObject option1;
    private GameObject option2;
    private GameObject option3;
    private GameObject option4;

    private int selectedOption = -2;  // exit node is -1
    
    public string DialogueDataFilePath;

    // Start is called before the first frame update
    void Start()
    {
        dia = Dialogue.LoadDialogue("Assets/Resources/Dialogues/" + DialogueDataFilePath);

        npcSpeechBubble = GameObject.Find("SpeechBubble");
        npcText = GameObject.Find("SpeechBubbleText");
        npcThoughtsBubble = GameObject.Find("ThoughtBubble");
        npcThoughtsText = GameObject.Find("ThoughtBubbleText");
        option1 = GameObject.Find("Option1");
        option2 = GameObject.Find("Option2");
        option3 = GameObject.Find("Option3");
        option4 = GameObject.Find("Option4");

        RunDialogue();
    }

    public void RunDialogue()
    {
        StartCoroutine(Run());
    }

    public void SetSelectedOption(int x)
    {
        selectedOption = x;
    }

    private void DisplayNode(DialogueNode node)
    {
        npcSpeechBubble.SetActive(false);
        if(node.Text.Length > 0)
        {
            npcText.GetComponent<Text>().text = node.Text;
            npcSpeechBubble.SetActive(true);
        }

        npcThoughtsBubble.SetActive(false);
        if (node.Thoughts.Length > 0)
        {
            npcThoughtsText.GetComponent<Text>().text = node.Thoughts;
            npcThoughtsBubble.SetActive(true);
        }

        option1.SetActive(false);
        option2.SetActive(false);
        option3.SetActive(false);
        option4.SetActive(false);

        for(int i = 0; i < node.Options.Count; i++)
        {
            switch (i)
            {
                case 0:
                    SetOptionBtn(option1, node.Options[i]);
                    break;
                case 1:
                    SetOptionBtn(option2, node.Options[i]);
                    break;
                case 2:
                    SetOptionBtn(option3, node.Options[i]);
                    break;
                case 3:
                    SetOptionBtn(option4, node.Options[i]);
                    break;
            }
        }
    }

    private void SetOptionBtn(GameObject btn, DialogueOption opt)
    {
        btn.SetActive(true);
        btn.GetComponentInChildren<Text>().text = opt.Text;
        btn.GetComponent<Button>().onClick.AddListener(delegate
        {
            SetSelectedOption(opt.DestNodeID);
        });
    }

    public IEnumerator Run()
    {
        int nodeId = 0;

        while (nodeId != -1)
        {
            for(int i = 0; i < dia.Nodes.Count; i++)
            {
                if (nodeId == dia.Nodes[i].NodeID)
                {
                    DisplayNode(dia.Nodes[i]);
                }
            }
            selectedOption = -2;
            while (selectedOption == -2)
            {
                yield return new WaitForSeconds(0.25f);
            }
            nodeId = selectedOption;
        }
    }
}
