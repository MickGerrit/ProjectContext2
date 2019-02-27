using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trees : MonoBehaviour {

    //Reference
    private GameManager gameManager;
    private SelectionArrow selectionArrow;
    private Stats stats;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        stats = gameManager.GetComponent<Stats>();
        selectionArrow = FindObjectOfType<SelectionArrow>();
        gameManager.trees.Add(this.gameObject);
    }

    public void GatherTreePerform()
    {
        stats.wood += 5f;
        selectionArrow.isSelecting = false;
        gameManager.trees.Remove(this.gameObject);
        Destroy(transform.gameObject, .1f);
    }

}
