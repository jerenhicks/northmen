using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializers : MonoBehaviour {

    public GameObject hexPrefab;
    public Material[] material;

    // Use this for initialization
    void Start () {
        MapController.instance.setPrefab(hexPrefab);
        MapController.instance.setTerrainMaterials(material);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
