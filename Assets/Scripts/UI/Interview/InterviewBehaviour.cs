using Assets.Scripts.UI.ItemSelection;
using System.Linq;
using UnityEngine;

public class InterviewBehaviour : MonoBehaviour
{
    public TextAsset jsonFile;
    public Items itemList;
    void Start()
    {
        itemList = JsonUtility.FromJson<Items>(jsonFile.text);

        foreach(Item item in itemList.items)
        {
            GameObject itemGameObject = GameObject.Find(item.itemName);
            itemGameObject.SetActive(false);
            Item selectedItem = PlayerData.selectedItems.SingleOrDefault(i => i.itemName == item.itemName);
            if (selectedItem != null)
            {
                itemGameObject.SetActive(true);
            }
        }
    }
}
