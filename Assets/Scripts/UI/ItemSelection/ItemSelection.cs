using Assets.Scripts.UI.ItemSelection;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemSelection : MonoBehaviour
{
    public TextAsset jsonFile;
    public Items itemList;
    public List<Item> selectedItems;

    private GameObject continueBtn;
    private bool itemCheckFinished;

    void Start()
    {
        itemList = JsonUtility.FromJson<Items>(jsonFile.text);
        continueBtn = GameObject.Find("ContinueButton");
        continueBtn.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(WaitUntilItemCheckFinished());
        });
    }
    public void CheckForSelectedItems()
    {
        itemCheckFinished = false;
        foreach (Item item in itemList.items)
        {
            GameObject itemGameObject = GameObject.Find(item.gameObjectName);
            if (itemGameObject)
            {
                if (itemGameObject.GetComponent<Toggle>().isOn && !selectedItems.Contains(item))
                {
                    selectedItems.Add(item);
                }
                else
                {
                    Item itemToRemove = itemList.items.SingleOrDefault(i => i.gameObjectName == item.gameObjectName);
                    if (itemToRemove != null)
                    {
                        selectedItems.Remove(itemToRemove);
                    }
                }
            }
        }
        itemCheckFinished = true;
    }

    private IEnumerator WaitUntilItemCheckFinished() 
    {
        while (!itemCheckFinished)
        {
            yield return null;
        }
        PlayerData.SelectedItems = selectedItems;
        SceneManager.LoadScene("Interview");
    }

    void Update()
    {
        CheckForSelectedItems();
    }
}
