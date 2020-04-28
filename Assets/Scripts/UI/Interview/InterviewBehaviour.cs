using Assets.Scripts.UI.ItemSelection;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
            if (!PlayerData.selectedItems.Contains(item))
            {
                itemGameObject.SetActive(false);
                Debug.Log("vänt");
            }
        }

    }
}
