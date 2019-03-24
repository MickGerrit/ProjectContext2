using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUIPositioner : MonoBehaviour {

    private Transform offsetLoc;
    private Transform followTarget;
    public Transform playerCamLoc;
    public Transform planet;

    public float offsetX;
    public float offsetY;
    public float zPosition;

    public bool canSelect;
    public bool isSelecting;
    private bool doOnce;

    public Camera cam;
    public LayerMask buildingLayerMask;
    public string UITag;
    public string deselectTag;
    public RaycastHit hit;
    public GameObject hitObject;
    public GameObject prevObject;


    // Use this for initialization
    void Start() {
        canSelect = true;
        doOnce = true;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        planet = GameObject.FindGameObjectWithTag("Planet").transform;
    }
    // Update is called once per frame
    void Update() {

        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1)) && isSelecting)
            ExitWindow();

        prevObject = hitObject;
        if (isSelecting) {
            for (int i = 0; i < transform.childCount; i++) {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            this.transform.position = new Vector3(hitObject.transform.position.x + offsetX, hitObject.transform.position.y + offsetY, zPosition);
            this.transform.LookAt(playerCamLoc);
        } else {
            hitObject = planet.transform.gameObject;
            for (int i = 0; i < transform.childCount; i++) {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        if (canSelect) {
            // Select
            if (Input.GetButtonDown("Fire1") && canSelect) {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, buildingLayerMask) && Input.GetButton("Fire1") && doOnce) {
                    doOnce = false;
                    isSelecting = true;
                    if (hit.transform.gameObject.tag != UITag) {
                        hitObject = hit.transform.gameObject;
                    }

                }
                if (Physics.Raycast(ray, out hit, Mathf.Infinity) && Input.GetButtonDown("Fire1") && hit.transform.gameObject != hitObject) {
                    if (hit.transform.gameObject.tag == deselectTag) {
                        isSelecting = false;
                    }
                }
            }
        }
        if (Input.GetButtonUp("Fire1"))
            doOnce = true;
    }

    public void ExitWindow() {
        isSelecting = false;
    }
}
