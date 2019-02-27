using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherResources : MonoBehaviour {

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
            if (Physics.Raycast(ray, out hit, Mathf.Infinity) && Input.GetButtonDown("Fire1") && hit.collider.gameObject.tag == "GatherWood"/*&& selectionArrow.prevObject == selectionArrow.hitObject*/)
            {
                if(selectionArrow.prevObject.tag == "Tree")
                    selectionArrow.prevObject.GetComponent<Trees>().GatherTreePerform();
                else if (selectionArrow.prevObject.tag == "Bush")
                    selectionArrow.prevObject.GetComponent<Bush>().GatherTreePerform();
                //facedGameObject = hit.transform.gameObject;
                //GameObject instantiatedPrefab;
                //instantiatedPrefab = Instantiate(prefab, hit.point, Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation);
                //instantiatedPrefab.transform.SetParent(planet);

                canGatherWood = false;
            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity) && Input.GetButtonDown("Fire1") && hit.collider.gameObject.tag == "GatherBush"/*&& selectionArrow.prevObject == selectionArrow.hitObject*/)
            {
                selectionArrow.prevObject.GetComponent<Bush>().GatherBushPerform();
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
