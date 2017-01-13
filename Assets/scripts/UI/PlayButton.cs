using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayButton : MonoBehaviour {

    Button myButton;

    void Awake() {
        myButton = GetComponent<Button>(); // <-- you get access to the button component here

        myButton.onClick.AddListener(() => { onClick(); });
        myButton.GetComponentsInChildren<Text>()[0].text = "Play";
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onClick() {
        Debug.Log("on click");
        if (TimeController.instance.isPlaying()) {
            TimeController.instance.pause();
            myButton.GetComponentsInChildren<Text>()[0].text = "Play";
        } else {
            TimeController.instance.play();
            myButton.GetComponentsInChildren<Text>()[0].text = "Pause";
        }
    }
}
