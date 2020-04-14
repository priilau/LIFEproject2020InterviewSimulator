using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComfortSlider : MonoBehaviour
{
    private GameObject comfortSlider;
    // Start is called before the first frame update
    void Start()
    {
        comfortSlider = GameObject.Find("ComfortSlider");
    }
    public void SetComfortValue(int value)
    {
        comfortSlider.GetComponent<Slider>().value += value;
    }
}
