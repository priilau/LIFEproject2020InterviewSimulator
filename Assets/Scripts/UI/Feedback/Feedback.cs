using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.UI.Feedback.FeedbackInfo;

public class Feedback : MonoBehaviour
{
    private GameObject prosAndConsContent;
    private GameObject infoContent;
    private GameObject textObject;
    void Start()
    {
        prosAndConsContent = GameObject.Find("ProsAndConsContent");
        infoContent = GameObject.Find("InfoContent");

        foreach (InfoPro pro in PlayerData.Pros)
        {
            Debug.Log(pro.info);
            textObject = new GameObject("Text");
            prosAndConsContent.transform.SetParent(this.transform);
            textObject.AddComponent<Text>().text = pro.info;
        }

        foreach (InfoCon con in PlayerData.Cons)
        {
            textObject = new GameObject("Text");
            prosAndConsContent.transform.SetParent(this.transform);
            textObject.AddComponent<Text>().text = con.info;
        }

        foreach (Info info in PlayerData.Info)
        {
            textObject = new GameObject("Text");
            infoContent.transform.SetParent(this.transform);
            textObject.AddComponent<Text>().text = info.info;
        }
    }
}
