using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public List<GameObject> trees = new List<GameObject>();
    public List<GameObject> factories = new List<GameObject>();
    public List<GameObject> population = new List<GameObject>();
    public List<GameObject> assignedpopulation = new List<GameObject>();
    public List<GameObject> workertree = new List<GameObject>();
    public List<GameObject> workerfarm = new List<GameObject>();
    public List<GameObject> workerfactory = new List<GameObject>();
    public List<GameObject> workermine = new List<GameObject>();
    public List<GameObject> selection = new List<GameObject>();
    public List<GameObject> windmill = new List<GameObject>();
    public List<GameObject> farm = new List<GameObject>();
    public List<GameObject> house1 = new List<GameObject>();
    public List<GameObject> house2 = new List<GameObject>();
    public List<GameObject> solarflower = new List<GameObject>();
    public List<GameObject> townhall = new List<GameObject>();

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
    public GameObject buildTownHallButton;
    public GameObject buildWindmillButton;
    public GameObject buildSolarflowerButton;
    public GameObject buildFarmButton;
    public GameObject victoryText;
    public GameObject failText;
    public GameObject gameUI;
    public GameObject tutBuildTownHallUI;
    public GameObject tutBuildStartUI;
    public Mine mine;
    private bool buildButtonBool;
    private bool buildButtonDoOnce;

    public int turnCount;
    private bool doOnce;
    
    [SerializeField]
    private float co2Force;
    public float gameTurnDuration;
    public float gemsEarned = 0f;

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
    public float windmillMultiplier;
    public float solarEnergy;
    public float solarPower;
    public float factoryPower;
    public float woodMultiplier;
    public float mineMultiplier;
    public float happinessDecreaseMultiplier;
    public float happinessIncreaseMultiplier;

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
        mineMultiplier = 120f;
        woodMultiplier = 1f;
        happinessIncreaseMultiplier = .8f;
        happinessDecreaseMultiplier = .1f;

        //Resource Variables
        windmillEnergy = .2f;
        windmillMultiplier = 3f;
        solarEnergy = 1f;
        solarPower = .4f;
        factoryPower = 1f;
}
	
	// Update is called once per frame
	void Update () {

        if (turnSystem.Turn == TurnSystem.turn.GameTurn && doOnce)
        {
            StartCoroutine(GameTurnCycle());
            doOnce = false;
        }
        if (townhall.Count > 0)
            stats.townhallStarter = false;

        stats.population = population.Count;

        //Tutorial
        if(stats.townhallStarter)
            tutBuildTownHallUI.SetActive(true);
        else
            tutBuildTownHallUI.SetActive(false);

        if (mine.minecartSent == false)
        {
            Debug.Log("MiepMiep");

        }
    }

    //Calculate C02
    public void CalculateC02()
    {
        stats.co2 = stats.co2 - -((co2Force - (trees.Count + -factories.Count)) /100f) * Time.deltaTime;
    }

    //Calculate Happiness
    public void CalculateHappiness()
    {
        stats.happiness = stats.happiness - (population.Count * happinessDecreaseMultiplier) * Time.deltaTime;
        stats.happiness = stats.happiness - ((workertree.Count + workerfactory.Count + workermine.Count) * happinessDecreaseMultiplier) * Time.deltaTime;
        stats.happiness = stats.happiness + (workerfarm.Count * happinessIncreaseMultiplier) * Time.deltaTime;
    }

    //Calculate Wood
    public void CalculateWood()
    {
        stats.wood = stats.wood + (workertree.Count * woodMultiplier)*Time.deltaTime;
    }

    //Calculate Power
    public void CalculatePower()
    {
        stats.power = stats.power + (factories.Count*factoryPower/10f) * Time.deltaTime;
        stats.power = stats.power + (windmill.Count * windmillMultiplier / 10f) * Time.deltaTime;
        stats.power = stats.power + (solarflower.Count * solarPower / 10f) * Time.deltaTime;
        stats.power = stats.power - (house2.Count * stats.house2PowerCost / 10f) * Time.deltaTime;
        stats.power = stats.power - (house1.Count * stats.house1PowerCost / 10f) * Time.deltaTime;
    }

    //Calculate Gem
    public void CalculateGem()
    {
        gemsEarned = stats.gem + (workermine.Count * mineMultiplier) * Time.deltaTime;
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
        if (!buildButtonBool && stats.townhallStarter)
            tutBuildStartUI.SetActive(true);

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
            buildTownHallButton.SetActive(true);
            tutBuildStartUI.SetActive(false);
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
            buildTownHallButton.SetActive(false);
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
