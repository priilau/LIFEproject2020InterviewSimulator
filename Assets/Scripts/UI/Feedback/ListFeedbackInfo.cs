using UnityEngine;
using Assets.Scripts.UI.Feedback.FeedbackInfo;

public class ListFeedbackInfo : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private GameObject item;
    [SerializeField]
    private RectTransform content;
    private int count = 0;
    void Start()
    {
        if(content.tag == "Pros")
        {
            content.sizeDelta = new Vector2(0, PlayerData.pros.Count * 145);
            foreach (InfoPro pro in PlayerData.pros)
            {
                float spawnY = count * 145;
                Vector3 pos = new Vector3(0, -spawnY, 0);
                GameObject spawnedItem = Instantiate(item, pos, spawnPoint.rotation);
                spawnedItem.transform.SetParent(spawnPoint, false);
                ProAndConDetails itemDetails = spawnedItem.GetComponent<ProAndConDetails>();
                itemDetails.itemInfo.text = pro.info;
                itemDetails.itemComment.text = pro.comment;
                count++;
            }
            count = 0;
        }

        if (content.tag == "Cons")
        {
            content.sizeDelta = new Vector2(0, PlayerData.cons.Count * 145);
            foreach (InfoCon con in PlayerData.cons)
            {
                float spawnY = count * 145;
                Vector3 pos = new Vector3(0, -spawnY, 0);
                GameObject spawnedItem = Instantiate(item, pos, spawnPoint.rotation);
                spawnedItem.transform.SetParent(spawnPoint, false);
                ProAndConDetails itemDetails = spawnedItem.GetComponent<ProAndConDetails>();
                itemDetails.itemInfo.text = con.info;
                itemDetails.itemComment.text = con.comment;
                count++;
            }
            count = 0;
        }

        if (content.tag == "Info")
        {
            content.sizeDelta = new Vector2(0, PlayerData.info.Count * 65);
            foreach (Info info in PlayerData.info)
            {
                float spawnY = count * 65;
                Vector3 pos = new Vector3(0, -spawnY, 0);
                GameObject spawnedItem = Instantiate(item, pos, spawnPoint.rotation);
                spawnedItem.transform.SetParent(spawnPoint, false);
                InfoItemDetails itemDetails = spawnedItem.GetComponent<InfoItemDetails>();
                itemDetails.itemInfo.text = info.info;
                count++;
            }
        }
    }
}
