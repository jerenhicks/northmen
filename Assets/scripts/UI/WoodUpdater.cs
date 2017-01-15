using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WoodUpdater : MonoBehaviour {

    private Text woodText;

    // Use this for initialization
    void Start() {
        woodText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        woodText.text = "" + PlayerController.instance.getWoodAmount();
    }
}
