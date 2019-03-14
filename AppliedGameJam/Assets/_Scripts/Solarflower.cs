using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solarflower : MonoBehaviour {

    //Reference
    private GameManager gameManager;
    private Stats stats;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        stats = gameManager.GetComponent<Stats>();
        gameManager.solarflower.Add(this.gameObject);
        stats.wood = stats.wood - stats.solarflowerWoodCost;
        stats.gem = stats.gem - stats.solarflowerGemCost;
    }

    public void DestroySolarFlower()
    {
        stats.wood += stats.solarflowerWoodCost/3;
        gameManager.solarflower.Remove(this.gameObject);
        Destroy(transform.gameObject, .1f);
    }
}
