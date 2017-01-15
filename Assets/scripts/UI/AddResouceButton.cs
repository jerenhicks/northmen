using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AddResouceButton : MonoBehaviour {

    Button addResourceButton;

    void Awake() {
        addResourceButton = GetComponent<Button>(); // <-- you get access to the button component here

        addResourceButton.onClick.AddListener(() => { onClick(); });
    }

    public void onClick() {
        PlayerController.instance.changeFoodAmount(1);
        PlayerController.instance.changeGoldAmount(-1);
        PlayerController.instance.changeWoodAmount(2);
    }
}
