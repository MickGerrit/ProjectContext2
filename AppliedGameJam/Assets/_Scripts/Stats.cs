using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour {

    //Reference
    public Slider co2Slider;
    public Slider foodSlider;
    public Slider powerSlider;

    public float co2;
    public float food;
    public float power;

	// Use this for initialization
	void Start () {
        co2 = 50f;
        food = 0f;
        power = 0f;
	}

    private void Update()
    {
        co2Slider.value = co2/100;
        foodSlider.value = food/100;
        powerSlider.value = power/100;
    }
}
