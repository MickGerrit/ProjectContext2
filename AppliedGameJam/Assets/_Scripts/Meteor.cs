using System.Collections;
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

	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<GameManager>();
        meteorStartPos = this.transform;
        journeyLength = Vector3.Distance(meteorStartPos.position, planet.transform.position);
        doOnce = true;
        turns = 10;
    }
	
	// Update is called once per frame
	void Update () {
		if(turnSystem.Turn == TurnSystem.turn.GameTurn)
        {
            // Move towards target according divided by how many turns it should take
            if (doOnce)
            {
                movDirection = Vector3.MoveTowards(this.transform.position, planet.transform.position, journeyLength / (turns-1));
                doOnce = false;
            }
            this.transform.position = Vector3.Slerp(meteorStartPos.transform.position, movDirection, gameManager.gameTurnDuration/100);
        }
        if (turnSystem.Turn == TurnSystem.turn.PlayerTurn)
            doOnce = true;
    }
}
