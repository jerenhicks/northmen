using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hex : MonoBehaviour {

    public int x;
    public int y;

    public hex[] GetNeighbours() {
        GameObject.Find("Hex_" + (x - 1) + "_" + y);
        return null;
    }
}
