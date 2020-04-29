using UnityEngine;

public class NPCBehaviours : MonoBehaviour
{
    private static int helper = 0;
    private GameObject approve1;
    private GameObject approve2;
    private GameObject disapprove;
    private GameObject NPCimage;
    private Sprite activeSprite;

    private void SetNPCImage()
    {
        activeSprite = Resources.Load<Sprite>("Images/NPCs/Judy/judy" + NPCData.GetComfortValue());
        NPCimage = GameObject.Find("NPCImg");
        NPCimage.GetComponent<UnityEngine.UI.Image>().sprite = activeSprite;
    }

    private void SetNPCaudio()
    {
        approve1 = GameObject.Find("Approving1");
        approve1 = GameObject.Find("Approving2");
        disapprove = GameObject.Find("Disapproving2");
        if (NPCData.npcComfortValue > helper){
            approve1.SetActive(true);
            helper++;
        } else if (NPCData.npcComfortValue < helper)
        {
            disapprove.SetActive(true);
            helper--;
        }
    }

    void Start()
    {
        SetNPCImage();
        SetNPCaudio();
    }
    
    // Update is called once per frame
    void Update()
    {
        SetNPCImage();
        SetNPCaudio();
    }
}
