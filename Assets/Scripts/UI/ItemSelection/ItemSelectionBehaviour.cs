using Assets.Scripts.UI.ItemSelection;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemSelectionBehaviour : MonoBehaviour
{
    public TextAsset jsonFile;
    public Items itemList;
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
        CheckForSelectedItems();
    }
    public void CheckForSelectedItems()
    {
        itemCheckFinished = false;
        foreach (Item item in itemList.items)
        {
            GameObject itemGameObject = GameObject.Find(item.itemName);
            if (itemGameObject)
            {
                if (itemGameObject.GetComponent<Toggle>().isOn && !PlayerData.selectedItems.Contains(item))
                {
                    PlayerData.selectedItems.Add(item);
                }
                if (!itemGameObject.GetComponent<Toggle>().isOn && PlayerData.selectedItems.Contains(item))
                {
                    Item itemToRemove = itemList.items.SingleOrDefault(i => i.itemName == item.itemName);
                    if (itemToRemove != null)
                    {
                        PlayerData.selectedItems.Remove(itemToRemove);
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
        SceneManager.LoadScene("Interview");
    }

    void Update()
    {
        if (itemCheckFinished)
        {
            CheckForSelectedItems();
        }
    }
}
