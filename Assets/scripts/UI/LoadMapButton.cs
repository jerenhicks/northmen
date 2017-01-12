using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoadMapButton : MonoBehaviour {

    Button loadMapButton;

    void Awake() {
        loadMapButton = GetComponent<Button>(); // <-- you get access to the button component here

        loadMapButton.onClick.AddListener(() => { onClick(); });
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onClick() {
        Debug.Log("on click loading");

        MapController.controller.loadMapFromFile();

    }
}
