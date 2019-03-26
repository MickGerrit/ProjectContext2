using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverToGetStats : ObjectSelecter {

    public GameObject currentGameObject;
    private GameManager gameManager;
    public float hoverMinimum;
    public float currentHoveringTime;
    private ObjectUIPositioner objectUIPositioner;
    public PlanetRotationControls planetRotationControls;
    public GameObject hoverCanvas;
    public Text co2;
    public Text happiness;
    public Text wood;
    public Text gems;
    public Text power;
    public Text sustainableEnergy;
    public ObjectPlacer objectPlacer;
    // Use this for initialization
    void Awake () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        sceneCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        objectUIPositioner = GetComponent<ObjectUIPositioner>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!Input.GetButton("Fire1") && !objectUIPositioner.blockOtherRayCasts) {
            currentHoveringTime += Time.deltaTime;
        }
        if ((Input.GetButton("Fire1") && objectUIPositioner.blockOtherRayCasts || currentGameObject == null) && objectUIPositioner.hitObject == null) {
            currentHoveringTime = 0;
            hoverCanvas.SetActive(false);
        }
        this.transform.position = new Vector3(currentGameObject.transform.position.x + objectUIPositioner.offsetX, 
            currentGameObject.transform.position.y + objectUIPositioner.offsetY, objectUIPositioner.zPosition);
        this.transform.LookAt(objectUIPositioner.playerCamLoc);

        if (currentHoveringTime >= hoverMinimum) {
            planetRotationControls.CancelInvoke();
            hoverCanvas.SetActive(true);
            GetProductionAndDisplayIt();
            Debug.Log("Hovering");
        }
	}

    void GetProductionAndDisplayIt() {
        if (currentGameObject.tag == "House1") {
            if ((1 * gameManager.stats.house1PowerCost / 10f) * gameManager.gameTurnDuration > 0)
                power.text = "-" + (1 * gameManager.stats.house1PowerCost / 10f) * gameManager.gameTurnDuration;
            else power.text = "x";
            happiness.text = "x";
            co2.text = "x";
            wood.text = "x";
            gems.text = "x";
            sustainableEnergy.text = "x";
        }
        if (currentGameObject.tag == "House2") {
            if ((1 * gameManager.stats.house2PowerCost / 10f) * gameManager.gameTurnDuration > 0)
                power.text = "-" + (1 * gameManager.stats.house2PowerCost / 10f) * gameManager.gameTurnDuration;
            power.text = "x";
            happiness.text = "x";
            co2.text = "x";
            wood.text = "x";
            gems.text = "x";
            sustainableEnergy.text = "x";
        }
        if (currentGameObject.tag == "House3") {
            happiness.text = "x";
            co2.text = "x";
            wood.text = "x";
            gems.text = "x";
            power.text = "x";
            sustainableEnergy.text = "x";
        }
        if (currentGameObject.tag == "Farm") {
            if ((currentGameObject.GetComponent<Occupance>().occupanceAmount) * gameManager.gameTurnDuration > 0)
                happiness.text = "+" + (currentGameObject.GetComponent<Occupance>().occupanceAmount) * gameManager.gameTurnDuration;
            else happiness.text = "x";
            co2.text = "x";
            wood.text = "x";
            gems.text = "x";
            power.text = "x";
            sustainableEnergy.text = "x";
        }
        if (currentGameObject.tag == "Windmill") {
            if ((1 * gameManager.windmillMultiplier / 10f) * gameManager.gameTurnDuration > 0)
                power.text = "+" + (1 * gameManager.windmillMultiplier / 10f) * gameManager.gameTurnDuration;
            else power.text = "x";
            if ((1 * gameManager.windmillEnergy / 200f) > 0)
                sustainableEnergy.text = "+" + (1 * gameManager.windmillEnergy / 200f);
            else sustainableEnergy.text = "x";
            happiness.text = "x";
            co2.text = "x";
            wood.text = "x";
            gems.text = "x";
        }
        if (currentGameObject.tag == "Factory") {
            if (((gameManager.co2Force - (1 + -gameManager.factories.Count)) / 100f) * gameManager.gameTurnDuration > 0)
                co2.text = "+" + ((gameManager.co2Force - (1 + -gameManager.factories.Count)) / 100f) * gameManager.gameTurnDuration;
            else co2.text = "x";
            if ((currentGameObject.GetComponent<Occupance>().occupanceAmount) * gameManager.gameTurnDuration > 0)
                happiness.text = "-" + (currentGameObject.GetComponent<Occupance>().occupanceAmount) * gameManager.gameTurnDuration;
            else happiness.text = "x";
            power.text = "+" + (1 * gameManager.factoryPower / 10f) * gameManager.gameTurnDuration;
            wood.text = "x";
            gems.text = "x";
            sustainableEnergy.text = "x";
        }
        if (currentGameObject.tag == "Solarflower") {
            if ((1 * gameManager.solarEnergy / 200f) > 0)
                sustainableEnergy.text = "+" + (1 * gameManager.solarEnergy / 200f);
            else sustainableEnergy.text = "x";
            if ((1 * gameManager.solarPower / 10f) * gameManager.gameTurnDuration > 0)
                power.text = "+" + (1 * gameManager.solarPower / 10f) * gameManager.gameTurnDuration;
            else power.text = "x";
            happiness.text = "x";
            co2.text = "x";
            wood.text = "x";
            gems.text = "x";
        }
        if (currentGameObject.tag == "TownHall") {
            happiness.text = "x";
            co2.text = "x";
            wood.text = "x";
            gems.text = "x";
            power.text = "x";
            sustainableEnergy.text = "x";
        }
        if (currentGameObject.tag == "Tree") {
            if (((gameManager.co2Force - (gameManager.trees.Count + -1)) / 100f) * gameManager.gameTurnDuration > 0)
                co2.text = "-" + ((gameManager.co2Force - (gameManager.trees.Count + -1)) / 100f) * gameManager.gameTurnDuration;
            else co2.text = "x";

            if ((currentGameObject.GetComponent<Occupance>().occupanceAmount) * gameManager.gameTurnDuration > 0) {
                happiness.text = "-" + (currentGameObject.GetComponent<Occupance>().occupanceAmount) * gameManager.gameTurnDuration;
            } else happiness.text = "x";
            if ((currentGameObject.GetComponent<Occupance>().occupanceAmount * gameManager.woodMultiplier) * gameManager.gameTurnDuration > 0) {
                wood.text = "+" + (currentGameObject.GetComponent<Occupance>().occupanceAmount * gameManager.woodMultiplier) * gameManager.gameTurnDuration;
            } else wood.text = "x";
            gems.text = "x";
            power.text = "x";
            sustainableEnergy.text = "x";
        }
        if (currentGameObject.tag == "Mine") {
            if ((currentGameObject.GetComponent<Occupance>().occupanceAmount) * gameManager.gameTurnDuration > 0)
                happiness.text = "-" + (currentGameObject.GetComponent<Occupance>().occupanceAmount) * gameManager.gameTurnDuration;
            else happiness.text = "x";
            if ((currentGameObject.GetComponent<Occupance>().occupanceAmount * gameManager.mineMultiplier) * gameManager.gameTurnDuration > 0)
                gems.text = "+" + (currentGameObject.GetComponent<Occupance>().occupanceAmount * gameManager.mineMultiplier) * gameManager.gameTurnDuration;
            else gems.text = "x";
            co2.text = "x";
            wood.text = "x";
            power.text = "x";
            sustainableEnergy.text = "x";
        }
        if (currentGameObject.tag == "Seed") {

        }
    }


    private void FixedUpdate() {
        if (objectUIPositioner.hitObject != null) {
            currentGameObject = objectUIPositioner.hitObject;
            currentHoveringTime = hoverMinimum;
        } else if (objectPlacer.instantiatedPrefab == null){
            currentGameObject = GetGameObjectWhileHovering(layerMask, sceneCamera);
        }
    }
}
