using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingOnUIHandler : ObjectSelecter {

    public Text objectInformationBox;
    public Text occupanceAmountBox;
    private GameObject UIBox;
    public Image image;
    // Use this for initialization
    private void Start() {
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (GetGameObjectOnClick(layerMask, sceneCamera).tag != "World Space") {
            clickedGameObject = GetGameObjectOnClick(layerMask, sceneCamera);
        }
        if (clickedGameObject != null) {
            objectInformationBox.text = clickedGameObject.GetComponent<Occupance>().informationAboutBuilding;
            occupanceAmountBox.text = clickedGameObject.GetComponent<Occupance>().occupanceAmount.ToString() + "/" + clickedGameObject.GetComponent<Occupance>().maximumOccupanceAmount.ToString();
            image.sprite = clickedGameObject.GetComponent<Occupance>().sprite;
        }

    }

    //Inhancement: here we can also put a function to check wich layer or tag the click gameobject has and than change a stat in the stat script


    public void AddWorker() {
        Debug.Log("Add Worker");
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
