using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trees : MonoBehaviour {

    //Reference
    public GameManager gameManager;
    public Stats stats;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        stats = gameManager.GetComponent<Stats>();
        gameManager.trees.Add(this.gameObject);
    }

    public void GatherTreePerform()
    {
        stats.wood += 5f;
        gameManager.trees.Remove(this.gameObject);
        Destroy(transform.gameObject, .1f);
    }

}
