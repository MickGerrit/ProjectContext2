using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenteredObjectChecker : MonoBehaviour {
    private Camera cam;
    [SerializeField]
    private GameObject facedGameObject;
    public LayerMask layerMask;
    private SoundChanger soundChanger;
	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
        soundChanger = GetComponent<SoundChanger>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask)) {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            facedGameObject = hit.transform.gameObject;
        }

        //change sound
        if (facedGameObject.tag == "Woods") {
            soundChanger.biome = 1;
        } else if (facedGameObject.tag == "Desert") {
            soundChanger.biome = 2;
        } else if (facedGameObject.tag == "Ice") {
            soundChanger.biome = 3;
        } 
    }
}
