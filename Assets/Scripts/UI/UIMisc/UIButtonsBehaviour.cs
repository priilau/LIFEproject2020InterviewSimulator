using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonsBehaviour : MonoBehaviour
{
    private Sprite muteSprite;
    private Sprite unmuteSprite;
    private GameObject muteBtn;

    void Start()
    {
        muteBtn = GameObject.Find("muteBtn");
        unmuteSprite = Resources.Load<Sprite>("Images/Icons/unmute");
        muteSprite = Resources.Load<Sprite>("Images/Icons/mute");
        if (Music.muted)
        {
            muteBtn.GetComponent<UnityEngine.UI.Image>().sprite = unmuteSprite;
        }
        else
        {
            muteBtn.GetComponent<UnityEngine.UI.Image>().sprite = muteSprite;
        }
        
        muteBtn.GetComponent<Button>().onClick.AddListener(delegate
        {
            if (Music.muted)
            {
                Music.muted = false;
                AudioListener.volume = 1;
                muteBtn.GetComponent<UnityEngine.UI.Image>().sprite = muteSprite;
            }
            else
            {
                Music.muted = true;
                AudioListener.volume = 0;
                muteBtn.GetComponent<UnityEngine.UI.Image>().sprite = unmuteSprite;
            }
        });
    }
}
