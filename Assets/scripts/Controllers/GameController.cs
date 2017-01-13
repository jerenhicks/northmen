using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void newGame(string name, string mapName) {
        PlayerController.instance.newPlayer(name);
        MapController.instance.loadMapFromFile();
    }

    public void saveGame() {

    }

    public void loadGame() {

    }
}
