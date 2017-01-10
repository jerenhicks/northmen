using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class MouseManager : MonoBehaviour {

    Unit selectedUnit;
    private hex previousSelectedHex;

	// Use this for initialization
	void Start () {
		
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

            //MeshRenderer mr = ourHitObject.GetComponentInChildren<MeshRenderer>();

            //if (mr.material.color == Color.red) {
            //    mr.material.color = Color.white;
            //}
            //else {
            //    mr.material.color = Color.red;
            //}

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
}
