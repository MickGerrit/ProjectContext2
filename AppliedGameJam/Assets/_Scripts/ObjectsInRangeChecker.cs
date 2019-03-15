using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInRangeChecker : MonoBehaviour {
    
    public GameObject[] gameObjectArray;
    public float[] distanceArray;
    public float radius;
    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        gameObjectArray = GetObjectsInRange(transform.position, radius);
        distanceArray = GetDistances(transform.position, gameObjectArray);
    }


    public GameObject[] GetObjectsInRange(Vector3 vector3Position, float sphereRadius) {
        Collider[] hitColliders;
        hitColliders = Physics.OverlapSphere(vector3Position, sphereRadius);
        GameObject[] gameObjects;
        gameObjects = new GameObject[hitColliders.Length];
        for (int i = 0; i < hitColliders.Length; i++) {
            gameObjects[i] = hitColliders[i].gameObject;
        }
        return gameObjects;
    }

    public float[] GetDistances(Vector3 vector3Position, GameObject[] gameObjects) {
        float[] distances = new float[gameObjects.Length];
        for (int i = 0; i < gameObjects.Length; i++) {
            distances[i] = Vector3.Distance(vector3Position, gameObjects[i].transform.position);
        }
        return distances;
    }

    public void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
