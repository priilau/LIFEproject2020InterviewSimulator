using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FeedBackBehaviour : MonoBehaviour
{
    private GameObject continueBtn;

    void Start()
    {
        continueBtn = GameObject.Find("ContinueButton");
        continueBtn.GetComponent<Button>().onClick.AddListener(delegate
        {
            SceneManager.LoadScene("MainMenu");
        });
    }
}
