using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour {

    public enum turn {PlayerTurn, GameTurn, EventTurn};
    public turn Turn;

    //Reference
    private GameManager gameManager;
    private GatherResources gatherResources;
    public PlanetRotationControls planetRotationControls;
    public Text endTurnText;

	// Use this for initialization
	void Start () {
        gameManager = GetComponent<GameManager>();
        gatherResources = GetComponent<GatherResources>();
	}
	
	// Update is called once per frame
	void Update () {
        switch (Turn)
        {
            // The idle playerState
            case turn.PlayerTurn:
                endTurnText.enabled = true;
                planetRotationControls.staticRotationInvokeTime = 4f;
                planetRotationControls.staticRotationSpeed = 15f;
                gatherResources.GatherResourcesPerform();
                break;

            // The wandering playerState
            case turn.GameTurn:
                planetRotationControls.staticRotationInvokeTime = 0f;
                endTurnText.enabled = false;
                gameManager.CalculateC02();
                gameManager.CalculatePower();
                gameManager.CalculateEnergy();
                gameManager.LoseConditions();
                break;

            // The roaming playerState
            case turn.EventTurn:

                break;
        }
    }
}
