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
        Debug.Log(content.tag);
        if(content.tag == "Pros")
        {
            content.sizeDelta = new Vector2(0, PlayerData.pros.Count * 60);
            foreach (InfoPro pro in PlayerData.pros)
            {
                float spawnY = count * 60;
                Vector3 pos = new Vector3(spawnPoint.position.x, -spawnY, spawnPoint.position.z);
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
            content.sizeDelta = new Vector2(0, PlayerData.cons.Count * 60);
            foreach (InfoCon con in PlayerData.cons)
            {
                float spawnY = count * 60;
                Vector3 pos = new Vector3(spawnPoint.position.x, -spawnY, spawnPoint.position.z);
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
            content.sizeDelta = new Vector2(0, PlayerData.info.Count * 60);
            foreach (Info info in PlayerData.info)
            {
                float spawnY = count * 60;
                Vector3 pos = new Vector3(spawnPoint.position.x, -spawnY, spawnPoint.position.z);
                GameObject spawnedItem = Instantiate(item, pos, spawnPoint.rotation);
                spawnedItem.transform.SetParent(spawnPoint, false);
                InfoItemDetails itemDetails = spawnedItem.GetComponent<InfoItemDetails>();
                itemDetails.itemInfo.text = info.info;
                count++;
            }
        }
    }
}
