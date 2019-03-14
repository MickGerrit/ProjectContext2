using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUIHandler : ObjectSelecter {

    public Text objectInformationBox;
    public Text occupanceAmountBox;
    public Image image;
    // Use this for initialization
    private void Start() {
    }

    // Update is called once per frame
    void Update() {
        clickedGameObject = GetGameObjectOnClick(layerMask, sceneCamera);
        if (clickedGameObject != null) {
            objectInformationBox.text = clickedGameObject.GetComponent<Occupance>().informationAboutBuilding;
            occupanceAmountBox.text = clickedGameObject.GetComponent<Occupance>().occupanceAmount.ToString() + "/" + clickedGameObject.GetComponent<Occupance>().maximumOccupanceAmount.ToString();
            image.sprite = clickedGameObject.GetComponent<Occupance>().sprite;
        }

    }

    public void AddWorker() {
        if (clickedGameObject.GetComponent<Occupance>().occupanceAmount < clickedGameObject.GetComponent<Occupance>().maximumOccupanceAmount) {
            clickedGameObject.GetComponent<Occupance>().occupanceAmount += 1;
        }
    }

    public void RemoveWorker() {
        if (clickedGameObject.GetComponent<Occupance>().occupanceAmount > 0) {
            clickedGameObject.GetComponent<Occupance>().occupanceAmount -= 1;
        }
    }


}
