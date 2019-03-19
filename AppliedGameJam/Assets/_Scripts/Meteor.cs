﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

    //Reference
    private Transform meteorStartPos;
    public Transform planet;
    public TurnSystem turnSystem;
    private GameManager gameManager;

    private float journeyLength;

    private float turns;
    private bool doOnce;
    private Vector3 movDirection;

    public float maxTurns = 15;
    private Vector3 wantedPosition;
	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<GameManager>();
        meteorStartPos = this.transform;
        journeyLength = Vector3.Distance(meteorStartPos.position, planet.transform.position);
        doOnce = true;
    }
	
	// Update is called once per frame
	void Update () {
		if(turnSystem.Turn == TurnSystem.turn.GameTurn)
        {
            // Move towards target according divided by how many turns it should take
            if (doOnce)
            {
                movDirection = gameManager.gameObject.transform.position;
                wantedPosition = Vector3.Lerp(meteorStartPos.transform.position, movDirection, (gameManager.turnCount + 1) / maxTurns);
                doOnce = false;
            }

            transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * 2);
        }
        if (turnSystem.Turn == TurnSystem.turn.PlayerTurn)
            doOnce = true;
    }
}
