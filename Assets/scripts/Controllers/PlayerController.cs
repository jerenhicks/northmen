using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;
    private string playerName;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void newPlayer(string name) {
        this.playerName = name;
    }

    public void loadPlayer(string name) {
        this.playerName = name;
    }

    public string getPlayerName() {
        return this.playerName;
    }
}
