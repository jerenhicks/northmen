using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour {

    public static TimeController instance = null;
    private static int month = 1;
    private static int day = 1;
    private static int year = 100;
    private float lastChange = 0f;
    private List<int> thirtyMonths = new List<int>(new int[]{4, 6, 9, 11});
    private List<int> thirtyOneMonths = new List<int>(new int[] {1,3,5,7,8,10,12});
    private List<string> months = new List<string>(new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" });
    private bool playing = false;

	// Use this for initialization
	void Start () {
        Debug.Log("hi there, timecontroller start");
	}

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update () {
        if (this.playing) {
            if (Time.time - lastChange > 1.0) {
                Debug.Log("updating time");
                addTime();
                lastChange = Time.time;
            }
        }
	}

    public string getTime() {
        string monthInString = months[month - 1];
        return "" + monthInString + " " + day + ", " + year;
    }

    public void pause() {
        this.playing = false;
    }

    public void play() {
        this.playing = true;
    }

    public bool isPlaying() {
        return this.playing;
    }

    private void addTime() {
        day++;
        Debug.Log("Day is = " + day + " Month is = " + month + " Year is = " + year);
        if (day == 28 && month == 2) {
            day = 1;
            month++;
        } else if (day > 30) {
            if (day == 31 && thirtyMonths.Contains(month)) {
                day = 1;
                month++;
            } else if (day == 32 && thirtyOneMonths.Contains(month)) {
                day = 1;
                if (month == 12) {
                    month = 1;
                    year++;
                }
                else {
                    month++;
                }
            }    
        } 
    }
}
