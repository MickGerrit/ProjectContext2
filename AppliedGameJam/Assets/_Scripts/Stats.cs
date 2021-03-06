﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour {

    //Reference
    public Slider co2Slider;
    public Slider happinessSlider;
    public Slider powerSlider;
    public Text populationAmount;
    public Text assignedPopulationAmount;
    public Text workersAmount;
    public Text happinessAmount;
    public Text woodAmount;
    public Text powerAmount;
    public Text gemAmount;
    public Text co2Amount;
    public Slider energySlider;
    public Text seedGemCostText;
    public Text house1WoodCostText;
    public Text house2WoodCostText;
    public Text house2GemCostText;
    public Text house3WoodCostText;
    public Text house3GemCostText;
    public Text townhallWoodCostText;
    public Text townhallGemCostText;
    public Text windmillWoodCostText;
    public Text factoryWoodCostText;
    public Text farmWoodCostText;
    public Text solarflowerWoodCostText;
    public Text solarflowerGemCostText;
    private GameManager gameManager;

    public float co2;

    //Resources
    public float food;
    public float power;
    public float wood;
    public int population;
    public float happiness;
    public float gem;
    public float energy;

    //Building Cost
    public int seedGemCost = 1;
    public int windmillWoodCost = 10;
    public int house1WoodCost = 15;
    public int house1PowerReqCost = 20;
    public float house1PowerCost = 1f;
    public int house2WoodCost = 15;
    public float house2PowerCost = 1.4f;
    public int house2GemCost = 10;
    public int house2PowerReqCost = 60;
    public int house3WoodCost = 35;
    public int house3GemCost = 15;
    public int farmWoodCost = 20;
    public int factoryWoodCost = 30;
    public int solarflowerWoodCost = 40;
    public int solarflowerGemCost = 20;
    public int townhallWoodCost = 80;
    public int townhallGemCost = 10;
    public bool townhallStarter = true;

    public float recycleMultiplier;

    // Use this for initialization
    void Start () {
        co2 = 50f;
        food = 0f;
        power = 0f;
        wood = 0f;
        happiness = 50f;
        gem = 0f;
        energy = 0f;
        recycleMultiplier = .33f;
        seedGemCostText.text = seedGemCost.ToString("F0");
        house1WoodCostText.text = house1WoodCost.ToString("F0");
        house2WoodCostText.text = house2WoodCost.ToString("F0");
        house2GemCostText.text = house2GemCost.ToString("F0");
        house3WoodCostText.text = house3WoodCost.ToString("F0");
        house3GemCostText.text = house3GemCost.ToString("F0");
        townhallWoodCostText.text = townhallWoodCost.ToString("F0");
        townhallGemCostText.text = townhallGemCost.ToString("F0");
        windmillWoodCostText.text = windmillWoodCost.ToString("F0");
        solarflowerWoodCostText.text = solarflowerWoodCost.ToString("F0");
        solarflowerGemCostText.text = solarflowerGemCost.ToString("F0");
        factoryWoodCostText.text = factoryWoodCost.ToString("F0");
        farmWoodCostText.text = farmWoodCost.ToString("F0");
        //Initialize
        gameManager = FindObjectOfType<GameManager>();
	}

    void Update()
    {
        energySlider.value = energy / 100;
        co2Slider.value = co2/100;
        happinessSlider.value = happiness/100;
        powerSlider.value = power/100;
        woodAmount.text = wood.ToString("F0");
        powerAmount.text = power.ToString("F0");
        happinessAmount.text = happiness.ToString("F0");
        populationAmount.text = (gameManager.population.Count + gameManager.assignedpopulation.Count + gameManager.workertree.Count + gameManager.workerfactory.Count + gameManager.workermine.Count + gameManager.workerfarm.Count).ToString();
        assignedPopulationAmount.text = (gameManager.assignedpopulation.Count+ gameManager.workertree.Count + gameManager.workerfactory.Count + gameManager.workermine.Count + gameManager.workerfarm.Count).ToString();
        workersAmount.text = (gameManager.workertree.Count + gameManager.workerfactory.Count + gameManager.workermine.Count + gameManager.workerfarm.Count).ToString();
        gemAmount.text = gem.ToString("F0");
        co2Amount.text = co2.ToString("F0");

        if (co2 < 0)
            co2 = 0;
    }
}
