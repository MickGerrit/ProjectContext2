﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour {

    private Stats stats;
    public GameObject debugScreen;

    private bool debugBool;

	// Use this for initialization
	void Start () {
        stats = GetComponent<Stats>();
        debugBool = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Alpha0) && !debugBool)
        {
            Debug.Log("1");
            debugScreen.SetActive(true);
            debugBool = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0) && debugBool)
        {
            Debug.Log("2");
            debugScreen.SetActive(false);
            debugBool = false;
        }


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