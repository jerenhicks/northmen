using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GoldUpdater : MonoBehaviour {

    private Text goldText;

	// Use this for initialization
	void Start () {
        goldText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        goldText.text = "" + PlayerController.instance.getGoldAmount();
    }
}
