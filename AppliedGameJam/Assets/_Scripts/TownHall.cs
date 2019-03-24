﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHall : MonoBehaviour {

    //Reference
    private GameManager gameManager;
    public Stats stats;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        stats = gameManager.GetComponent<Stats>();
        gameManager.townhall.Add(this.gameObject);
        if (!stats.townhallStarter)
        {
            stats.wood = stats.wood - stats.townhallWoodCost;
            stats.gem = stats.gem - stats.townhallGemCost;
        }
    }

    public void DestroyTownHall()
    {
        stats.wood += Mathf.RoundToInt(stats.townhallWoodCost / 3);
        gameManager.townhall.Remove(this.gameObject);
        Destroy(transform.gameObject, .1f);
    }
}
