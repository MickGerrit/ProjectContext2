using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerSelectorButton : WorkerSelecter {

    public bool canSelect = false;

    public LayerMask buildingLayer;
    public LayerMask workerLayer;
    public GameObject newWorker;
    public GameObject building;

    public GameObject addWorkerButton;

    public GameObject selectedBuilding;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
        clickedGameObject = GetGameObjectOnClick(layerMask, sceneCamera);

        EnableDisableButton();

        if (Input.GetKeyDown(KeyCode.Space)) {
            SetWorkerPosition(GetGameObjectOnClick(layerMask, sceneCamera), workerNewTransformPosition);
        }

        if (canSelect) {
            if (((1 << clickedGameObject.gameObject.layer) & workerLayer) != 0) {
                newWorker = clickedGameObject;
            }
            workerNewTransformPosition = selectedBuilding.GetComponent<Accupances>().GetNewAccupanceTransform();
            if (newWorker != null && workerNewTransformPosition != null) {
                Debug.Log("Go to transform");
                SetWorkerPosition(newWorker, workerNewTransformPosition);
                selectedBuilding.GetComponent<Accupances>().AccupanceAmount += 1;
                canSelect = false;
            }
        } else {
            newWorker = null;
        }

	}

    public void EnableDisableButton() {
        if (((1 << clickedGameObject.gameObject.layer) & buildingLayer) != 0) {
            selectedBuilding = clickedGameObject;
            addWorkerButton.SetActive(true);
            Debug.Log("WrokerLayer");
        } else addWorkerButton.SetActive(false);
    }

    public void ButtonToggle() {
        canSelect = !canSelect;
    }

    public void SetWorkerPosition(GameObject selectableWorker, Transform workerPosition) {
        selectableWorker.transform.position = workerPosition.position;
        selectableWorker.transform.rotation = workerPosition.rotation;
        selectableWorker.GetComponent<Character>().StopAllCoroutines();
        selectableWorker.GetComponent<Animator>().StopPlayback();   
        selectableWorker.GetComponent<Character>().enabled = false;
    }
}
