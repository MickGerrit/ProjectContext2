using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public List<GameObject> trees = new List<GameObject>();
    public List<GameObject> factories = new List<GameObject>();
    public List<GameObject> population = new List<GameObject>();
    public List<GameObject> selection = new List<GameObject>();
    public List<GameObject> windmill = new List<GameObject>();
    public List<GameObject> house2 = new List<GameObject>();
    public List<GameObject> solarflower = new List<GameObject>();

    //Reference
    private Trees treeList;
    private Stats stats;
    private TurnSystem turnSystem;
    public Text turnCountText;
    public GameObject buildTreeButton;
    public GameObject buildHouseButton;
    public GameObject buildHouse2Button;
    public GameObject buildHouse3Button;
    public GameObject buildFactoryButton;
    public GameObject buildWindmillButton;
    public GameObject buildSolarflowerButton;
    public GameObject buildFarmButton;
    public GameObject victoryText;
    public GameObject failText;
    public GameObject gameUI;
    private bool buildButtonBool;
    private bool buildButtonDoOnce;

    public int turnCount;
    private bool doOnce;
    
    [SerializeField]
    private float co2Force;
    public float gameTurnDuration;

    //public Camera cam;
    //public LayerMask layerMask;
    //public RaycastHit hit;
    //public GameObject hitObject;
    //public GameObject prevObject;
    //public GameObject selectionArrow;

    //Notitie
    bool test = (1 == 1);

    //Declare
    public float windmillEnergy;
    public float windmillPower;
    public float solarEnergy;
    public float solarPower;
    public float factoryPower;

    public float house2PowerCost;
    // Use this for initialization
    void Start () {
        stats = GetComponent<Stats>();
        treeList = GetComponent<Trees>();
        turnSystem = GetComponent<TurnSystem>();
        co2Force = trees.Count;
        gameTurnDuration = 5f;
        turnCount = 0;
        doOnce = true;
        buildButtonBool = true;

        //Resource Variables
        windmillEnergy = .3f;
        windmillPower = .15f;
        solarEnergy = 1f;
        solarPower = .4f;
        factoryPower = 1f;
        house2PowerCost = .4f;
    }
	
	// Update is called once per frame
	void Update () {

        if (turnSystem.Turn == TurnSystem.turn.GameTurn && doOnce)
        {
            StartCoroutine(GameTurnCycle());
            doOnce = false;
        }

        //prevObject = hitObject;
        //Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask) && Input.GetButton("Fire1") && doOnce)
        //{
        //    hitObject = hit.transform.gameObject;
        //    selectionArrow.SetActive(true);
        //}

        //if (Physics.Raycast(ray, out hit, Mathf.Infinity) && Input.GetButtonDown("Fire1") && hit.transform.gameObject != hitObject)
        //    selectionArrow.SetActive(false);


        //if(turnSystem.Turn == TurnSystem.turn.GameTurn)
        //{
        //    Time.timeScale = 10f;
        //}
        //else
        //{
        //    Time.timeScale = 1f;
        //}

        stats.population = population.Count;
    }

    //Calculate C02
    public void CalculateC02()
    {
        stats.co2 = stats.co2 - -((co2Force - (trees.Count+ -factories.Count)) /100f);
    }

    //Calculate Power
    public void CalculatePower()
    {
        stats.power = stats.power + (factories.Count*factoryPower/10f);
        stats.power = stats.power + (windmill.Count * windmillPower / 10f);
        stats.power = stats.power + (solarflower.Count * solarPower / 10f);
        stats.power = stats.power - (house2.Count * house2PowerCost / 10f);
    }

    //Calculate Energy
    public void CalculateEnergy()
    {
        stats.energy = stats.energy + (windmill.Count*windmillEnergy / 200f);
        stats.energy = stats.energy + (solarflower.Count * solarEnergy / 200f);
    }

    //End Player Turn
    public void EndPlayerTurn()
    {
        turnSystem.Turn = TurnSystem.turn.GameTurn;
    }

    public void OpenBuildButton()
    {
        if (buildButtonBool)
        {
            buildHouseButton.SetActive(true);
            buildHouse2Button.SetActive(true);
            buildHouse3Button.SetActive(true);
            buildTreeButton.SetActive(true);
            buildFactoryButton.SetActive(true);
            buildWindmillButton.SetActive(true);
            buildSolarflowerButton.SetActive(true);
            buildFarmButton.SetActive(true);
            buildButtonBool = false;
        }

        else if (!buildButtonBool)
        {
            buildHouseButton.SetActive(false);
            buildHouse2Button.SetActive(false);
            buildHouse3Button.SetActive(false);
            buildTreeButton.SetActive(false);
            buildFactoryButton.SetActive(false);
            buildWindmillButton.SetActive(false);
            buildSolarflowerButton.SetActive(false);
            buildFarmButton.SetActive(false);
            buildButtonBool = true;
        }
    }

    //Game Turn: Fastforward Duration
    IEnumerator GameTurnCycle()
    {
        turnSystem.planetRotationControls.staticRotationSpeed = 300f;
        yield return new WaitForSeconds(gameTurnDuration);
        turnCount += 1;
        turnCountText.text = turnCount.ToString();
        turnSystem.planetRotationControls.staticRotationSpeed = 0;
        yield return new WaitForSeconds(3f);
        turnSystem.Turn = TurnSystem.turn.PlayerTurn;
        doOnce = true;
    }

    //Game Ending Condition
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Meteor")
        {
            Time.timeScale = 0;
            gameUI.SetActive(false);
            if (stats.energy >= 100)
            {
                victoryText.SetActive(true);
            }
            else
            {
                failText.SetActive(true);
            }
        }
    }

    public void LoseConditions()
    {
        if(stats.power < 0 || stats.happiness < 0 || stats.co2 > 100)
        {
            Time.timeScale = 0;
            gameUI.SetActive(false);
            failText.SetActive(true);
        }
    }
}
