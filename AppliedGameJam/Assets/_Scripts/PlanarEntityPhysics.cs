using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanarEntityPhysics : MonoBehaviour {
    private Camera cam;
    [SerializeField]
    private GameObject facedGameObject;
    public LayerMask layerMask;
    [SerializeField]
    private float downwardRayOffset;

    // Update is called once per frame
    void FixedUpdate () {
        RaycastHit hit;
        // Does the ray intersect any objects ex\cluding the player layer
        if (Physics.Raycast(transform.position + transform.up *-downwardRayOffset, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layerMask)) {
            Debug.DrawRay(transform.position + transform.up * -downwardRayOffset, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            facedGameObject = hit.transform.gameObject;
            transform.position = hit.point;
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal)*transform.rotation;
        }
    }
}
