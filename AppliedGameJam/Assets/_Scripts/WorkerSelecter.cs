using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerSelecter : MonoBehaviour {
    public Transform workerNewTransformPosition;
    public GameObject worker;
    public Camera sceneCamera;
    public GameObject clickedGameObject;
    public LayerMask layerMask;
    // Use this for initialization
    void Start () {
        sceneCamera = GameObject.FindObjectOfType<Camera>();
	}

    public GameObject GetGameObjectOnClick(LayerMask layerMask, Camera camera) {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask) && Input.GetButton("Fire1")) {
            GameObject facedGameObject = hit.transform.gameObject;
            Debug.Log("Shooting raycast");
            return facedGameObject;
        } else return clickedGameObject;
    }
}
