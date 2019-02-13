﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public List<GameObject> trees = new List<GameObject>();

    //Reference
    private Trees treeList;
    private Stats stats;
    private TurnSystem turnSystem;
    public Text turnCountText;

    private int turnCount;
    private bool doOnce;
    
    [SerializeField]
    private float co2Force;
    [SerializeField]
    private float gameTurnDuration;

    //Notitie
    bool test = (1 == 1);

    // Use this for initialization
    void Start () {
        stats = GetComponent<Stats>();
        treeList = GetComponent<Trees>();
        turnSystem = GetComponent<TurnSystem>();
        co2Force = trees.Count;
        gameTurnDuration = 5f;
        turnCount = 0;
        doOnce = true;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(co2Force - trees.Count);

        if(turnSystem.Turn == TurnSystem.turn.GameTurn && doOnce)
        {
            StartCoroutine(GameTurnCycle());
            doOnce = false;
        }

        //if(turnSystem.Turn == TurnSystem.turn.GameTurn)
        //{
        //    Time.timeScale = 10f;
        //}
        //else
        //{
        //    Time.timeScale = 1f;
        //}
	}

    //Calculate C02
    public void CalculateC02()
    {
        stats.co2 = stats.co2 - -((co2Force - trees.Count)/100);
    }

    //End Player Turn
    public void EndPlayerTurn()
    {
        turnSystem.Turn = TurnSystem.turn.GameTurn;
    }

    //Game Turn: Fastforward Duration
    IEnumerator GameTurnCycle()
    {
        yield return new WaitForSeconds(gameTurnDuration);
        turnCount += 1;
        turnCountText.text = turnCount.ToString();
        turnSystem.Turn = TurnSystem.turn.PlayerTurn;
        doOnce = true;
    }
}
