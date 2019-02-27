using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public List<GameObject> trees = new List<GameObject>();
    public List<GameObject> population = new List<GameObject>();
    public List<GameObject> selection = new List<GameObject>();

    //Reference
    private Trees treeList;
    private Stats stats;
    private TurnSystem turnSystem;
    public Text turnCountText;
    public GameObject buildTreeButton;
    public GameObject buildHouseButton;
    private bool buildButtonBool;
    private bool buildButtonDoOnce;

    private int turnCount;
    private bool doOnce;
    
    [SerializeField]
    private float co2Force;
    [SerializeField]
    private float gameTurnDuration;

    //public Camera cam;
    //public LayerMask layerMask;
    //public RaycastHit hit;
    //public GameObject hitObject;
    //public GameObject prevObject;
    //public GameObject selectionArrow;

    //Notitie
    bool test = (1 == 1);

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
        stats.co2 = stats.co2 - -((co2Force - trees.Count)/100);
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
            buildTreeButton.SetActive(true);
            buildButtonBool = false;
        }

        else if (!buildButtonBool)
        {
            buildHouseButton.SetActive(false);
            buildTreeButton.SetActive(false);
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
}
