using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuBehaviour : MonoBehaviour
{
    private GameObject playBtn;
    private GameObject aboutBtn;
    private GameObject backBtn;
    private GameObject about;


    void Start()
    {
        playBtn = GameObject.Find("PlayBtn");
        playBtn.GetComponent<Button>().onClick.AddListener(delegate
        {
            SceneManager.LoadScene("Introduction");
        });

        aboutBtn = GameObject.Find("AboutBtn");
        about = GameObject.Find("About");
        aboutBtn.GetComponent<Button>().onClick.AddListener(delegate
        {
            about.SetActive(true);
        });

        backBtn = GameObject.Find("BackBtn");
        backBtn.GetComponent<Button>().onClick.AddListener(delegate
        {
            about.SetActive(false);
        });
        about.SetActive(false);
    }
}
