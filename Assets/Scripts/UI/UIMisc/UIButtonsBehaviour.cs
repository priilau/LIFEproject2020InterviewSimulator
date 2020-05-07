using UnityEngine;
using UnityEngine.UI;

public class UIButtonsBehaviour : MonoBehaviour
{
    private Sprite mutedSprite;
    private Sprite unmutedSprite;
    private GameObject muteBtn;

    void Start()
    {
        muteBtn = GameObject.Find("MuteBtn");
        unmutedSprite = Resources.Load<Sprite>("Images/Icons/unmute");
        mutedSprite = Resources.Load<Sprite>("Images/Icons/mute");
        if (Sound.muted)
        {
            muteBtn.GetComponent<UnityEngine.UI.Image>().sprite = mutedSprite;
        }
        else
        {
            muteBtn.GetComponent<UnityEngine.UI.Image>().sprite = unmutedSprite;
        }
        
        muteBtn.GetComponent<Button>().onClick.AddListener(delegate
        {
            if (Sound.muted)
            {
                Sound.muted = false;
                AudioListener.volume = 1;
                muteBtn.GetComponent<UnityEngine.UI.Image>().sprite = unmutedSprite;
            }
            else
            {
                Sound.muted = true;
                AudioListener.volume = 0;
                muteBtn.GetComponent<UnityEngine.UI.Image>().sprite = mutedSprite;
            }
        });
    }
}
