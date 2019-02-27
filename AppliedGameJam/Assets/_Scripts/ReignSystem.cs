using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReignSystem : MonoBehaviour {

    //Reference
    private Stats stats;
    public SelectionArrow selectionArrow;

    public Camera cam;
    private GameObject facedGameObject;
    private RaycastHit hit;
    public LayerMask layerMask;
    public Transform planet;
    public GameObject prefab;
    private bool canGatherWood;

    // Use this for initialization
    void Start () {
        stats = GetComponent<Stats>();
        canGatherWood = true;
	}
	
	// Update is called once per frame
	void Update () {
        CanGather();
	}

    public void GatherResourcesPerform()
    {
        if (canGatherWood)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask) && Input.GetButtonDown("Fire1") && selectionArrow.prevObject == selectionArrow.hitObject)
            {

                hit.transform.gameObject.GetComponent<Trees>().GatherTreePerform();
                //facedGameObject = hit.transform.gameObject;
                //GameObject instantiatedPrefab;
                //instantiatedPrefab = Instantiate(prefab, hit.point, Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation);
                //instantiatedPrefab.transform.SetParent(planet);

                canGatherWood = false;
            }
        }
    }

    private void CanGather()
    {
        if (selectionArrow.isSelecting == true)
            canGatherWood = true;
        else
            canGatherWood = false;
    }
}
