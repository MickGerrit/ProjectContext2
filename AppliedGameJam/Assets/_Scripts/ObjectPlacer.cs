using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour {
    public Camera cam;
    private GameObject facedGameObject;
    public LayerMask layerMask;
    public GameObject prefab;
    public Transform planet;
    private bool canPlaceObjects;

    private void Start() {
        canPlaceObjects = false;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (canPlaceObjects) {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask) && Input.GetButton("Fire1")) {
                facedGameObject =  hit.transform.gameObject;
                    GameObject instantiatedPrefab;
                        instantiatedPrefab = Instantiate(prefab, hit.point, Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation);
                    instantiatedPrefab.transform.SetParent(planet);

                canPlaceObjects = false;
            }
        }

    }

    public void CanPlaceAnObject(GameObject chosenObject) {
        canPlaceObjects = true;
        prefab = chosenObject;
    }
}
