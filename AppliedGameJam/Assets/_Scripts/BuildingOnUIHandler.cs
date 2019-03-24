using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingOnUIHandler : ObjectSelecter {

    private GameManager gameManager;
    private Stats stats;

    public Text objectInformationBox;
    public Text occupanceAmountBox;
    private GameObject UIBox;
    public GameObject DestroyBuildingButton;
    public ObjectUIPositioner uiPositioner;
    public Image image;
    public Animator animController;
    public Animator animController2;
    public Animator animController3;
    public ObjectUIPositioner objectUIPositioner;

    private bool doOnce;

    // Use this for initialization
    private void Start() {
        gameManager = FindObjectOfType<GameManager>();
        stats = gameManager.GetComponent<Stats>();
        doOnce = true;
        objectUIPositioner = transform.GetComponentInParent<ObjectUIPositioner>();
    }
    private void Update() {
        if (GetGameObjectOnClick(layerMask, sceneCamera).tag != "World Space") {
            clickedGameObject = GetGameObjectOnClick(layerMask, sceneCamera);
        }

        if(clickedGameObject.tag == "Tree" || clickedGameObject.tag == "Mine")
            DestroyBuildingButton.SetActive(false);
        else
            DestroyBuildingButton.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Delete))
            DestroyBuilding();
    }
    // Update is called once per frame
    void FixedUpdate() {
        if (clickedGameObject != null && clickedGameObject == objectUIPositioner.hitObject) {
            objectInformationBox.text = clickedGameObject.GetComponent<Occupance>().informationAboutBuilding;
            occupanceAmountBox.text = clickedGameObject.GetComponent<Occupance>().occupanceAmount.ToString() + "/" + clickedGameObject.GetComponent<Occupance>().maximumOccupanceAmount.ToString();
            image.sprite = clickedGameObject.GetComponent<Occupance>().sprite;
        }
    }

    //Inhancement: here we can also put a function to check wich layer or tag the click gameobject has and than change a stat in the stat script
    public void AddWorker() {
        Debug.Log("Add Worker");

        if (clickedGameObject.GetComponent<Occupance>().occupanceAmount < clickedGameObject.GetComponent<Occupance>().maximumOccupanceAmount) {
            if (clickedGameObject.tag == "TownHall")
            {
                if (stats.population > 0)
                {
                    GameObject inhabitant = gameManager.population[Random.Range(0, gameManager.population.Count-1)];
                    gameManager.population.Remove(inhabitant);
                    gameManager.assignedpopulation.Add(inhabitant);
                    clickedGameObject.GetComponent<Occupance>().occupanceAmount += 1;
                }
            }
            else if (clickedGameObject.tag == "House1")
            {
                if(stats.population > 0)
                {
                    GameObject inhabitant = gameManager.population[Random.Range(0, gameManager.population.Count-1)];
                    gameManager.population.Remove(inhabitant);
                    gameManager.assignedpopulation.Add(inhabitant);
                    clickedGameObject.GetComponent<Occupance>().occupanceAmount += 1;
                }
            }
            else if (clickedGameObject.tag == "House2")
            {
                if (stats.population > 0)
                {
                    GameObject inhabitant = gameManager.population[Random.Range(0, gameManager.population.Count - 1)];
                    gameManager.population.Remove(inhabitant);
                    gameManager.assignedpopulation.Add(inhabitant);
                    clickedGameObject.GetComponent<Occupance>().occupanceAmount += 1;
                }
            }
            else if (clickedGameObject.tag == "Tree")
            {
                if (gameManager.assignedpopulation.Count > 0)
                {
                    GameObject inhabitant = gameManager.assignedpopulation[Random.Range(0, gameManager.assignedpopulation.Count-1)];
                    gameManager.assignedpopulation.Remove(inhabitant);
                    gameManager.workertree.Add(inhabitant);
                    clickedGameObject.GetComponent<Occupance>().occupanceAmount += 1;
                }
                else
                    NoWorkers();
            }
            else if (clickedGameObject.tag == "Farm")
            {
                if (gameManager.assignedpopulation.Count > 0)
                {
                    GameObject inhabitant = gameManager.assignedpopulation[Random.Range(0, gameManager.assignedpopulation.Count - 1)];
                    gameManager.assignedpopulation.Remove(inhabitant);
                    gameManager.workerfarm.Add(inhabitant);
                    clickedGameObject.GetComponent<Occupance>().occupanceAmount += 1;
                }
                else
                    NoWorkers();
            }
            else if (clickedGameObject.tag == "Factory")
            {
                if (gameManager.assignedpopulation.Count > 0)
                {
                    GameObject inhabitant = gameManager.assignedpopulation[Random.Range(0, gameManager.assignedpopulation.Count-1)];
                    gameManager.assignedpopulation.Remove(inhabitant);
                    gameManager.workerfactory.Add(inhabitant);
                    clickedGameObject.GetComponent<Occupance>().occupanceAmount += 1;
                }
                else
                    NoWorkers();
            }
            else if (clickedGameObject.tag == "Mine")
            {
                if (gameManager.assignedpopulation.Count > 0)
                {
                    GameObject inhabitant = gameManager.assignedpopulation[Random.Range(0, gameManager.assignedpopulation.Count-1)];
                    gameManager.assignedpopulation.Remove(inhabitant);
                    gameManager.workermine.Add(inhabitant);
                    clickedGameObject.GetComponent<Occupance>().occupanceAmount += 1;
                }
                else
                    NoWorkers();
            }
        }
    }

    public void RemoveWorker() {
        if (clickedGameObject.GetComponent<Occupance>().occupanceAmount > 0) {
            if (clickedGameObject.tag == "TownHall")
            {
                if(gameManager.assignedpopulation.Count < 1 && (gameManager.workerfarm.Count + gameManager.workertree.Count + gameManager.workerfactory.Count + gameManager.workermine.Count > 0)){
                    Debug.Log("Take A Worker");
                    EveryoneIsWorking();
                }
                else
                {
                    Debug.Log("Take From TownHall");
                    int listRange;
                    if (gameManager.assignedpopulation.Count == 0)
                        listRange = 0;
                    else
                        listRange = gameManager.assignedpopulation.Count-1;
                    GameObject inhabitant = gameManager.assignedpopulation[Random.Range(0, listRange)];
                    gameManager.assignedpopulation.Remove(inhabitant);
                    gameManager.population.Add(inhabitant);
                    clickedGameObject.GetComponent<Occupance>().occupanceAmount -= 1;
                }

            }
            else if (clickedGameObject.tag == "House1")
            {
                if (gameManager.assignedpopulation.Count < 1 && (gameManager.workerfarm.Count + gameManager.workertree.Count + gameManager.workerfactory.Count + gameManager.workermine.Count > 0))
                {
                    Debug.Log("Take A Worker");
                }
                else
                {
                    Debug.Log("Take From House");
                    int listRange;
                    if (gameManager.assignedpopulation.Count == 0)
                        listRange = 0;
                    else
                        listRange = gameManager.assignedpopulation.Count - 1;
                    GameObject inhabitant = gameManager.assignedpopulation[Random.Range(0, listRange)];
                    gameManager.assignedpopulation.Remove(inhabitant);
                    gameManager.population.Add(inhabitant);
                    clickedGameObject.GetComponent<Occupance>().occupanceAmount -= 1;
                }
            }
            else if (clickedGameObject.tag == "House2")
            {
                if (gameManager.assignedpopulation.Count < 1 && (gameManager.workerfarm.Count + gameManager.workertree.Count + gameManager.workerfactory.Count + gameManager.workermine.Count > 0))
                {
                    Debug.Log("Take A Worker");
                }
                else
                {
                    Debug.Log("Take From House");
                    int listRange;
                    if (gameManager.assignedpopulation.Count == 0)
                        listRange = 0;
                    else
                        listRange = gameManager.assignedpopulation.Count - 1;
                    GameObject inhabitant = gameManager.assignedpopulation[Random.Range(0, listRange)];
                    gameManager.assignedpopulation.Remove(inhabitant);
                    gameManager.population.Add(inhabitant);
                    clickedGameObject.GetComponent<Occupance>().occupanceAmount -= 1;
                }
            }
            else if (clickedGameObject.tag == "Tree")
            {
                    GameObject inhabitant = gameManager.workertree[Random.Range(0, gameManager.workertree.Count-1)];
                    gameManager.workertree.Remove(inhabitant);
                    gameManager.assignedpopulation.Add(inhabitant);
                    clickedGameObject.GetComponent<Occupance>().occupanceAmount -= 1;
            }
            else if (clickedGameObject.tag == "Farm")
            {
                GameObject inhabitant = gameManager.workerfarm[Random.Range(0, gameManager.workerfarm.Count - 1)];
                gameManager.workerfarm.Remove(inhabitant);
                gameManager.assignedpopulation.Add(inhabitant);
                clickedGameObject.GetComponent<Occupance>().occupanceAmount -= 1;
            }
            else if (clickedGameObject.tag == "Factory")
            {
                GameObject inhabitant = gameManager.workerfactory[Random.Range(0, gameManager.workerfactory.Count-1)];
                gameManager.workerfactory.Remove(inhabitant);
                gameManager.assignedpopulation.Add(inhabitant);
                clickedGameObject.GetComponent<Occupance>().occupanceAmount -= 1;
            }
            else if (clickedGameObject.tag == "Mine")
            {
                GameObject inhabitant = gameManager.workermine[Random.Range(0, gameManager.workermine.Count)];
                gameManager.workermine.Remove(inhabitant);
                gameManager.assignedpopulation.Add(inhabitant);
                clickedGameObject.GetComponent<Occupance>().occupanceAmount -= 1;
            }
        }
    }

    public void DestroyBuilding()
    {
        bool doOnce = true;
        uiPositioner.ExitWindow();
        if ((clickedGameObject.tag == "TownHall" || clickedGameObject.tag == "House1" || clickedGameObject.tag == "House2" || clickedGameObject.tag == "House3") && doOnce)
        {
            for (int i = 0; i < clickedGameObject.GetComponent<Occupance>().occupanceAmount; i++)
            {
                GameObject inhabitant = gameManager.assignedpopulation[Random.Range(0, gameManager.assignedpopulation.Count)];
                gameManager.assignedpopulation.Remove(inhabitant);
                gameManager.population.Add(inhabitant);
            }
        }
        if (clickedGameObject.tag == "TownHall" && doOnce)
        {
            stats.wood += Mathf.RoundToInt(stats.townhallWoodCost * stats.recycleMultiplier);
            gameManager.townhall.Remove(this.gameObject);
        }
        if (clickedGameObject.tag == "House1" && doOnce)
        {
            stats.wood += Mathf.RoundToInt(stats.house1WoodCost * stats.recycleMultiplier);
            gameManager.house1.Remove(this.gameObject);
        }
        if (clickedGameObject.tag == "House2" && doOnce)
        {
            stats.wood += Mathf.RoundToInt(stats.house2WoodCost * stats.recycleMultiplier);
            gameManager.house2.Remove(this.gameObject);
        }
        if (clickedGameObject.tag == "House3" && doOnce)
        {
            stats.wood += Mathf.RoundToInt(stats.house3WoodCost * stats.recycleMultiplier);
            gameManager.house3.Remove(this.gameObject);
        }
        if (clickedGameObject.tag == "Windmill" && doOnce)
        {
            stats.wood += Mathf.RoundToInt(stats.windmillWoodCost * stats.recycleMultiplier);
            gameManager.windmill.Remove(this.gameObject);
        }
        if (clickedGameObject.tag == "Factory" && doOnce)
        {
            stats.wood += Mathf.RoundToInt(stats.factoryWoodCost * stats.recycleMultiplier);
            gameManager.factories.Remove(this.gameObject);
        }
        if (clickedGameObject.tag == "Farm" && doOnce)
        {
            stats.wood += Mathf.RoundToInt(stats.farmWoodCost * stats.recycleMultiplier);
            gameManager.farm.Remove(this.gameObject);
        }

        doOnce = false;
        Destroy(clickedGameObject.GetComponentInParent<Transform>().parent.gameObject);
    }

    private void NoWorkers()
    {
        if (doOnce)
        {
            if (gameManager.assignedpopulation.Count < 1)
            {
                Debug.Log("Playing Animation");
                StartCoroutine(NoWorkersFadeAnimation());
                doOnce = false;
            }
        }
    }

    private void EveryoneIsWorking()
    {
        if (doOnce)
        {
            if (gameManager.assignedpopulation.Count < 1)
            {
                Debug.Log("Playing Animation");
                StartCoroutine(EveryoneIsWorkingFadeAnimation());
                doOnce = false;
            }
        }
    }


    IEnumerator NoWorkersFadeAnimation()
    {
        animController2.Play("NoWorkersFade");
        yield return new WaitForSeconds(1.25f);
        doOnce = true;
    }

    IEnumerator EveryoneIsWorkingFadeAnimation()
    {
        animController3.Play("EveryoneIsWorkingFade");
        yield return new WaitForSeconds(1.25f);
        doOnce = true;
    }



}
