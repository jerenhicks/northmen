using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TerrainType : MonoBehaviour {

    private Text terrainTypeText;

    // Use this for initialization
    void Start() {
        terrainTypeText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        if (MouseController.instance.isTileSelected()) {
            terrainTypeText.text = "" + MouseController.instance.getTileSelected().getTerrainType();
        }
    }
}
