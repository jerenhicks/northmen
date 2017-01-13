using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NewGameButton : MonoBehaviour {

    Button newGameButton;

    void Awake() {
        newGameButton = GetComponent<Button>(); // <-- you get access to the button component here

        newGameButton.onClick.AddListener(() => { onClick(); });
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onClick() {
        GameController.instance.newGame("Jeren", "something");
    }
}
