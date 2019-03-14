using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour {

    //Reference
    public Slider co2Slider;
    public Slider happinessSlider;
    public Slider powerSlider;
    public Text populationAmount;
    public Text happinessAmount;
    public Text woodAmount;
    public Text powerAmount;
    public Text gemAmount;
    public Text co2Amount;
    public Slider energySlider;
    private GameManager gameManager;

    public float co2;

    //Resources
    public float food;
    public float power;
    public float wood;
    public float population;
    public float happiness;
    public float gem;
    public float energy;

    //Building Cost
    public int seedWoodCost = 1;
    public int windmillWoodCost = 10;
    public int house1WoodCost = 15;
    public int house2WoodCost = 15;
    public int house2GemCost = 10;
    public int house3WoodCost = 35;
    public int house3GemCost = 15;
    public int farmWoodCost = 20;
    public int factoryWoodCost = 30;
    public int solarflowerWoodCost = 40;
    public int solarflowerGemCost = 20;

    // Use this for initialization
    void Start () {
        co2 = 50f;
        food = 0f;
        power = 0f;
        wood = 0f;
        happiness = 50f;
        gem = 0f;
        energy = 0f;

        //Initialize
        gameManager = FindObjectOfType<GameManager>();
	}

    void Update()
    {
        energySlider.value = energy / 100;
        co2Slider.value = co2/100;
        happinessSlider.value = happiness/100;
        powerSlider.value = power/100;
        woodAmount.text = wood.ToString();
        powerAmount.text = power.ToString("F0");
        happinessAmount.text = happiness.ToString();
        populationAmount.text = population.ToString();
        gemAmount.text = gem.ToString();
        co2Amount.text = co2.ToString("F0");
    }
}
