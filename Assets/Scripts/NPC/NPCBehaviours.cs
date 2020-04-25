using UnityEngine;

public class NPCBehaviours : MonoBehaviour
{
    private GameObject NPCimage;
    private Sprite activeSprite;
    private void SetNPCImage()
    {
        activeSprite = Resources.Load<Sprite>("Images/NPCs/Judy/judy" + NPCData.GetComfortValue());
        NPCimage = GameObject.Find("NPCImg");
        NPCimage.GetComponent<UnityEngine.UI.Image>().sprite = activeSprite;
    }
    void Start()
    {
        SetNPCImage();
    }
    
    // Update is called once per frame
    void Update()
    {
        SetNPCImage();
    }
}
