using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trees : MonoBehaviour {

    public List<GameObject> trees = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tree")
        {
            trees.Add(other.gameObject);
        }     
    }
}
