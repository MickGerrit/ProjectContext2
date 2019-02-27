using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour {

    //Reference
    public Slider co2Slider;
    public Slider foodSlider;
    public Slider powerSlider;
    public Text populationAmount;
    public Text foodAmount;
    public Text woodAmount;
    public Text powerAmount;
    private GameManager gameManager;

    public float co2;

    //Resources
    public float food;
    public float power;
    public float wood;
    public float population;
    public float happiness;

	// Use this for initialization
	void Start () {
        co2 = 50f;
        food = 0f;
        power = 0f;
        wood = 0f;
        happiness = 50f;
        //Initialize
        gameManager = FindObjectOfType<GameManager>();
	}

    void Update()
    {
        co2Slider.value = co2/100;
        foodSlider.value = food/100;
        powerSlider.value = power/100;
        woodAmount.text = wood.ToString();
        foodAmount.text = food.ToString();
        populationAmount.text = population.ToString();
    }
}
