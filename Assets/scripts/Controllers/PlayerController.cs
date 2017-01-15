using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;
    private string playerName;
    private int goldAmount;
    private int woodAmount;
    private int foodAmount;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void newPlayer(string name) {
        this.playerName = name;
        this.goldAmount = 100;
        this.woodAmount = 75;
        this.foodAmount = 50;
    }

    public void loadPlayer(string name) {
        this.playerName = name;
    }

    public string getPlayerName() {
        return this.playerName;
    }

    public void changeGoldAmount(int amountToChange) {
        this.goldAmount += amountToChange;
    }

    public int getGoldAmount() {
        return this.goldAmount;
    }

    public void changeWoodAmount(int amountToChange) {
        this.woodAmount += amountToChange;
    }

    public int getWoodAmount() {
        return this.woodAmount;
    }

    public void changeFoodAmount(int amountToChange) {
        this.foodAmount += amountToChange;
    }

    public int getFoodAmount() {
        return this.foodAmount;
    }
}
