using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour {

    public enum turn { PlayerTurn, GameTurn, EventTurn};
    public turn Turn;

    //Reference
    private GameManager gameManager;
    public Text playerTurnText;

	// Use this for initialization
	void Start () {
        gameManager = GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        switch (Turn)
        {
            // The idle playerState
            case turn.PlayerTurn:
                playerTurnText.enabled = true;
                break;

            // The wandering playerState
            case turn.GameTurn:
                playerTurnText.enabled = false;
                gameManager.CalculateC02();
                break;

            // The roaming playerState
            case turn.EventTurn:

                break;
        }
    }
}
