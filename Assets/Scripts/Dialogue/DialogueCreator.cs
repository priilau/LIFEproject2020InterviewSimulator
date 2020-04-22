using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

using DialogueTree;
using UnityEngine.SceneManagement;
using Assets.Scripts.UI.ItemSelection;
using Assets.Scripts.UI.Feedback.FeedbackInfo;

public class DialogueCreator : MonoBehaviour
{
    private Dialogue dia;

    private GameObject npcSpeechBubble;
    private GameObject npcText;
    private GameObject npcThoughtsBubble;
    private GameObject npcThoughtsText;
    private GameObject playerTextBubble;
    private GameObject playerText;
    private GameObject option1;
    private GameObject option2;
    private GameObject option3;
    private GameObject option4;
    private GameObject comfortSlider;
    private IEnumerator displayTextCoroutine;
    private bool isCoroutineRunning = false;
    private int selectedOption = -2;  // exit node is -1
    private FeedbackData feedbackData;

    public string DialogueDataFilePath;
    public TextAsset feedbackDataJsonFile;

    void Start()
    {
        dia = Dialogue.LoadDialogue("Assets/Resources/Dialogues/" + DialogueDataFilePath);
        feedbackData = JsonUtility.FromJson<FeedbackData>(feedbackDataJsonFile.text);

        npcSpeechBubble = GameObject.Find("SpeechBubble");
        npcText = GameObject.Find("SpeechBubbleText");
        npcThoughtsBubble = GameObject.Find("ThoughtBubble");
        npcThoughtsText = GameObject.Find("ThoughtBubbleText");
        playerTextBubble = GameObject.Find("PlayerTextBubble");
        playerText = GameObject.Find("PlayerTextBubbleText");
        option1 = GameObject.Find("Option1");
        option2 = GameObject.Find("Option2");
        option3 = GameObject.Find("Option3");
        option4 = GameObject.Find("Option4");
        comfortSlider = GameObject.Find("ComfortSlider");

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

    private IEnumerator DisplayText(string text, GameObject textObject)
    {
        isCoroutineRunning = true;
        char[] textChars;
        string newText;
        
        textChars = text.ToCharArray(0, text.Length);
        for (int i = 0; i < textChars.Length; i++)  // TODO: pause for ~3 seconds when "[PAUSE]" is encountered
        {
            newText = npcText.GetComponent<Text>().text;
            textObject.GetComponent<Text>().text = newText + textChars[i];
            yield return new WaitForSeconds(0.03f);
        }
        isCoroutineRunning = false;
    }
    
    private void NodeActions(DialogueNode node)
    {
        playerTextBubble.SetActive(false);
        if (node.PlayerText.Length > 0)
        {
            playerText.GetComponent<Text>().text = node.PlayerText;
            playerTextBubble.SetActive(true);
            // TODO: make the text write one letter at a time correctly. This needs to finish before the options become visible.
            //displayTextCoroutine = DisplayText(node.PlayerText, playerText);
            //StartCoroutine(displayTextCoroutine);
        }

        npcSpeechBubble.SetActive(false);
        if (node.Text.Length > 0)
        {
            npcText.GetComponent<Text>().text = "";
            npcSpeechBubble.SetActive(true);
            displayTextCoroutine = DisplayText(node.Text, npcText);
            StartCoroutine(displayTextCoroutine);
        }

        npcThoughtsBubble.SetActive(false);
        if (node.Thoughts.Length > 0)
        {
            npcThoughtsText.GetComponent<Text>().text = node.Thoughts;
            npcThoughtsBubble.SetActive(true);
        }

        if (node.ScaleValue != 0)
        {
            comfortSlider.GetComponent<NPCData>().SetComfortValue(node.ScaleValue);
        }

        if (node.Pro.Length > 0)
        {
            string[] proIds = node.Pro.Split(',');
            foreach (InfoPro pro in feedbackData.pros)
            {
                if(Array.IndexOf(proIds, pro.id) > -1)
                {
                    PlayerData.Pros.Add(pro);
                }
            }
        }

        if (node.Con.Length > 0)
        {
            string[] conIds = node.Con.Split(',');
            foreach (InfoCon con in feedbackData.cons)
            {
                if (Array.IndexOf(conIds, con.id) > -1)
                {
                    PlayerData.Cons.Add(con);
                }
            }
        }

        if (node.Info.Length > 0)
        {
            string[] infoIds = node.Pro.Split(',');
            foreach (Info info in feedbackData.info)
            {
                if (Array.IndexOf(infoIds, info.id) > -1)
                {
                    PlayerData.Info.Add(info);
                }
            }
        }
    }

    private void DisplayNode(DialogueNode node)
    {
        NodeActions(node);

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
        string optText = SetOptionText(opt);
        if (optText.Length == 0)
        {
            return;
        }
        btn.SetActive(true);
        btn.GetComponentInChildren<Text>().text = optText;
        btn.GetComponent<Button>().onClick.AddListener(delegate
        {
            if (opt.Pro.Length > 0)
            {
                string[] proIds = opt.Pro.Split(',');
                foreach (InfoPro pro in feedbackData.pros)
                {
                    if (Array.IndexOf(proIds, pro.id) > -1)
                    {
                        PlayerData.Pros.Add(pro);
                    }
                }
            }

            if (opt.Con.Length > 0)
            {
                string[] conIds = opt.Con.Split(',');
                foreach (InfoCon con in feedbackData.cons)
                {
                    if (Array.IndexOf(conIds, con.id) > -1)
                    {
                        PlayerData.Cons.Add(con);
                    }
                }
            }

            SetSelectedOption(opt.DestNodeID);
            if (isCoroutineRunning)
            {
                StopCoroutine(displayTextCoroutine);
            }
            if(opt.DestNodeID == -1) 
            {
                SceneManager.LoadScene("Feedback");
            }
        });
    }

    private string SetOptionText(DialogueOption opt)
    {
        string optionText;
        string specialItemsString = "";
        bool neededItemExists = false;
        if (opt.SpecialInteractionItems.Length > 0)
        {
            string[] specialItemsList = opt.SpecialInteractionItems.Split(',');
            foreach(Item item in PlayerData.SelectedItems)
            {
                if(Array.IndexOf(specialItemsList, item.itemName) > -1)
                {
                    neededItemExists = true;
                    specialItemsString += item.itemName + ", ";
                }
            }
            if(specialItemsString.Length > 0)
            {
                specialItemsString = specialItemsString.Remove(specialItemsString.Length - 2);
            }
            if (neededItemExists)
            {
                if (opt.Text.Contains("[ITEM_LIST]"))
                {
                    optionText = opt.Text.Replace("[ITEM_LIST]", specialItemsString);
                }
                else
                {
                    optionText = opt.Text;
                }
            } 
            else
            {
                optionText = "";
            }
        }
        else 
        {
            optionText = opt.Text;
        }
        if (opt.Text.Contains("[PLAYER_NAME]"))
        {
            optionText = opt.Text.Replace("[PLAYER_NAME]", PlayerData.playerName);
        }
        return optionText;
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
