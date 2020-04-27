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
    private GameObject aboutMenu;


    void Start()
    {
        playBtn = GameObject.Find("PlayBtn");
        playBtn.GetComponent<Button>().onClick.AddListener(delegate
        {
            SceneManager.LoadScene("Introduction");
        });

        aboutBtn = GameObject.Find("AboutBtn");
        aboutMenu = GameObject.Find("AboutMenu");
        aboutBtn.GetComponent<Button>().onClick.AddListener(delegate
        {
            aboutMenu.SetActive(true);
        });

        backBtn = GameObject.Find("BackBtn");
        backBtn.GetComponent<Button>().onClick.AddListener(delegate
        {
            aboutMenu.SetActive(false);
        });
    }

}
