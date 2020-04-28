using Assets.Scripts.UI.ItemSelection;
using UnityEngine;

public class InterviewBehaviour : MonoBehaviour
{
    public TextAsset jsonFile;
    public Items itemList;
    void Start()
    {
        itemList = JsonUtility.FromJson<Items>(jsonFile.text);

        foreach (Item item in itemList.items)
        {
            GameObject itemGameObject = GameObject.Find(item.gameObjectName);
            if (itemGameObject)
            {
                Debug.Log(itemGameObject);
                if (!PlayerData.selectedItems.Contains(item))
                {
                    itemGameObject.SetActive(false);
                }
            }
        }
    }
}
