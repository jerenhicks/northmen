using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FoodUpdater : MonoBehaviour {

    private Text foodText;

    // Use this for initialization
    void Start() {
        foodText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        foodText.text = "" + PlayerController.instance.getFoodAmount();
    }
}
