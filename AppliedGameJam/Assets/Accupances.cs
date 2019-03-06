using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accupances : MonoBehaviour {

    public int maximumAccupanceAmount;
    public int AccupanceAmount;
    public Transform[] workerPositions;
    

	public Transform GetNewAccupanceTransform() {
        if (AccupanceAmount < maximumAccupanceAmount) {
            return workerPositions[AccupanceAmount];
        } else return null;
    }
}
