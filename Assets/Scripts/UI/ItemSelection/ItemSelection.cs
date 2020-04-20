using Assets.Scripts.UI.JSONReader;
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

    private bool continueBtnClicked = false;
    private GameObject continueBtn;

    // Start is called before the first frame update
    void Start()
    {
        itemList = JsonUtility.FromJson<Items>(jsonFile.text);
        continueBtn = GameObject.Find("ContinueButton");
        continueBtn.GetComponent<Button>().onClick.AddListener(delegate
        {
            continueBtnClicked = true;
            PlayerData.SelectedItems = selectedItems;
            SceneManager.LoadScene("Interview");
        });
        RunSelection();
    }

    public void CheckForSelectedItems() // if the items are spammed, it wont register the toggle value quick enough to add it to the list
    {
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
                    if(itemToRemove != null)
                    {
                        selectedItems.Remove(itemToRemove);
                    }
                }
            }
        }
    }

    public void RunSelection()
    {
        StartCoroutine(Run());
    }

    private IEnumerator Run()
    {
        while(!continueBtnClicked)
        {
            CheckForSelectedItems();
            yield return new WaitForSeconds(0.001f);
        }
    }
}
