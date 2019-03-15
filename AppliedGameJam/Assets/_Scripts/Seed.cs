﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour {

    public List<GameObject> treetypes = new List<GameObject>();

    //Reference
    private GameManager gameManager;
    private Stats stats;
    private Transform planet;

    private int seedTurnCost = 2;
    private int turnCounter;

    private bool doOnce;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        planet = FindObjectOfType<PlanetRotationControls>().transform;
        stats = gameManager.GetComponent<Stats>();
        stats.wood = stats.wood - stats.seedWoodCost;
        turnCounter = gameManager.turnCount;
        doOnce = true;
    }

    private void Update()
    {
        if(gameManager.turnCount - turnCounter >= seedTurnCost && doOnce)
        {
            HatchPerform();
            doOnce = false;
        }    
    }

    public void HatchPerform()
    {
        GameObject instantiatedPrefab;
        GameObject prefab = treetypes[Random.Range(0,3)];
        instantiatedPrefab = Instantiate(prefab, this.transform.position, this.transform.rotation);
        instantiatedPrefab.transform.SetParent(planet);
        Destroy(transform.gameObject, .1f);
    }
}