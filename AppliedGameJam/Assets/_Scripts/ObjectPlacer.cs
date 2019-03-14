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
    private RaycastHit hit;

    public Animator animController;

    private GameManager gameManager;
    private Stats stats;

    //Declare
    private bool doOnce;

    private void Start() {
        canPlaceObjects = false;
        gameManager = FindObjectOfType<GameManager>();
        stats = gameManager.GetComponent<Stats>();
        doOnce = true;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (canPlaceObjects) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask) && Input.GetButtonUp("Fire1")) {
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
        if (chosenObject.tag == "Windmill" && stats.wood >= stats.windmillWoodCost)
            prefab = chosenObject;
        else if (chosenObject.tag == "Seed" && stats.wood >= stats.seedWoodCost)
            prefab = chosenObject;
        else if (chosenObject.tag == "House1" && stats.wood >= stats.house1WoodCost)
            prefab = chosenObject;
        else if (chosenObject.tag == "House2" && stats.wood >= stats.house2WoodCost && stats.gem >= stats.house2GemCost)
            prefab = chosenObject;
        else if (chosenObject.tag == "House3" && stats.wood >= stats.house3WoodCost && stats.gem >= stats.house3GemCost)
            prefab = chosenObject;
        else if (chosenObject.tag == "Farm" && stats.wood >= stats.farmWoodCost)
            prefab = chosenObject;
        else if (chosenObject.tag == "Factory" && stats.wood >= stats.factoryWoodCost)
            prefab = chosenObject;
        else if (chosenObject.tag == "Solarflower" && stats.wood >= stats.solarflowerWoodCost && stats.gem >= stats.solarflowerGemCost)
            prefab = chosenObject;
        else
        {
            canPlaceObjects = false;
            if (doOnce)
            {
                StartCoroutine(NoResourcesFadeAnimation());
                doOnce = false;
            }
        }
    }

    IEnumerator NoResourcesFadeAnimation()
    {
        animController.Play("NoResourcesFade");
        yield return new WaitForSeconds(1.25f);
        doOnce = true;
    }

}
