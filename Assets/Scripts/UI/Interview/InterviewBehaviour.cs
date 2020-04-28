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
            // for some reason this doesn't work here but works in ItemSelection.cs line 34
            /*
            if (itemGameObject && PlayerData.selectedItems.Contains(item))
            {
                itemGameObject.SetActive(false);
            }
             */
            if (itemGameObject)
            {
                foreach(Item selectedItem in PlayerData.selectedItems)
                {
                    if(selectedItem.itemName != item.itemName)
                    {
                        itemGameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
