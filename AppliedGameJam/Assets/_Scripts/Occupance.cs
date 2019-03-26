using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Occupance : MonoBehaviour {
    [TextArea]
    public string informationAboutBuilding;
    public int maximumOccupanceAmount;
    public int occupanceAmount;
    public Sprite sprite;


    public bool canAssign;
    
    public bool collidingWithGameObject;

    private string[] noOverlapTags = new string[] { "Townhall" };
    
    private void OnCollisionStay(Collision collision) {
        for (int t = 0; t<noOverlapTags.Length; t++) {
            if (collision.gameObject.tag == noOverlapTags[t]) {
                Debug.Log("Another TownHall, cant build here");
                collidingWithGameObject = true;
                return;
            }

        }
    }
    private void OnCollisionExit(Collision collision) {
        collidingWithGameObject = false;
    }
}
