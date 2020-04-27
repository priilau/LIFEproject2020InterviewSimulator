using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.UI.Feedback.FeedbackInfo;

public class Feedback : MonoBehaviour
{
    private GameObject prosContent;
    private GameObject consContent;
    private GameObject infoContent;
    private GameObject textObject;
    private Font font;
    private int fontSize = 14;
    void Start()
    {
        font = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        prosContent = GameObject.Find("ProsContent");
        consContent = GameObject.Find("ConsContent");
        infoContent = GameObject.Find("InfoContent");/*
        RectTransform prosScrollRect = GameObject.Find("Pros").GetComponent<ScrollRect>();
        DefaultControls.Resources TempResource = new DefaultControls.Resources();
        GameObject NewText = DefaultControls.CreateButton(TempResource);
        NewText.AddComponent<LayoutElement>();
        NewText.transform.SetParent(FindContent(prosScrollRect));*/

        foreach (InfoPro pro in PlayerData.Pros)
        {
            Debug.Log(pro.info);
            textObject = new GameObject("Text");
            textObject.transform.SetParent(prosContent.transform);
            textObject.AddComponent<Text>().font = font;
            textObject.GetComponent<Text>().fontSize = fontSize;
            textObject.GetComponent<Text>().text = pro.info;
        }

        foreach (InfoCon con in PlayerData.Cons)
        {
            textObject = new GameObject("Text");
            consContent.transform.SetParent(this.transform);
            textObject.AddComponent<Text>().text = con.info;
        }

        foreach (Info info in PlayerData.Info)
        {
            textObject = new GameObject("Text");
            infoContent.transform.SetParent(this.transform);
            textObject.AddComponent<Text>().text = info.info;
        }
    }

    private RectTransform FindContent(GameObject scrollViewObject)
    {
        RectTransform retVal = null;
        Transform[] temp = scrollViewObject.GetComponentsInChildren<Transform>();
        foreach (Transform child in temp)
        {
            if (child.name == "Content") 
            { 
                retVal = child.gameObject.GetComponent<RectTransform>(); 
            }
        }
        return retVal;
    }
}
