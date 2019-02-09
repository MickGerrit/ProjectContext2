using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour {

    private Stats stats;

	// Use this for initialization
	void Start () {
        stats = GetComponent<Stats>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            stats.co2 += 1f;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            stats.food += 1f;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            stats.power += 1f;
        }
    }
}
