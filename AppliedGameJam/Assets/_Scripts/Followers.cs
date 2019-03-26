using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followers : MonoBehaviour {

    //Reference
    public Transform followerSpawn;
    public GameObject prefab;
    public Transform planet;
    public GameManager gameManager;
    private bool doOnce;

    private float followerAmount;

	// Use this for initialization
	void Start () {
        doOnce = true;
	}
	
	// Update is called once per frame
	void Update () {
        //max followers on 100% happiness = 6
        followerAmount = Mathf.RoundToInt(gameManager.GetComponent<Stats>().happiness/16.7f);

        if (gameManager.GetComponent<TurnSystem>().Turn == TurnSystem.turn.GameTurn)
            doOnce = true;

		if(gameManager.GetComponent<TurnSystem>().Turn == TurnSystem.turn.PlayerTurn && doOnce)
        {
            for(int i = 0; i < followerAmount; i++)
            {
                GameObject instantiatedPrefab;
                instantiatedPrefab = Instantiate(prefab, followerSpawn.transform.position, Quaternion.identity);
                instantiatedPrefab.transform.SetParent(planet);
                instantiatedPrefab.transform.localScale = Vector3.one;
            }

            doOnce = false;
        }
	}
}
