using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class MouseController : MonoBehaviour {

    Unit selectedUnit;
    private hex previousSelectedHex;
    public static MouseController instance = null;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update () {
        //Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo)) {
            GameObject ourHitObject = hitInfo.collider.transform.parent.gameObject;

            if (ourHitObject.GetComponent<hex>() != null) {
             //   Debug.Log("its a hex");
                processHexClick(ourHitObject);
            } else if (ourHitObject.GetComponent<Unit>() != null) {
                processUnitClick(ourHitObject);
            }
        }
	}

    void processHexClick(GameObject ourHitObject) {
        if (Input.GetMouseButtonDown(0)) {

            if (previousSelectedHex != null) {
                previousSelectedHex.unselect();
            }

            hex hex = ourHitObject.GetComponent<hex>();
            hex.select();
            
            previousSelectedHex = hex;

            if (selectedUnit != null) {
                selectedUnit.destination = ourHitObject.transform.position;
            }
        }
    }

    void processUnitClick(GameObject ourHitObject) {
        if (Input.GetMouseButtonDown(0)) {
            selectedUnit = ourHitObject.GetComponent<Unit>();
        }
    }

    public bool isTileSelected() {
        return previousSelectedHex != null;
    }

    public MapTile getTileSelected() {
        if (previousSelectedHex == null) {
            return null;
        }
        else {
            return previousSelectedHex.getMapTile();
        }
    }

    public bool isUnitSelected() {
        return selectedUnit != null;
    }

}
