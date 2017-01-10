using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Map : MonoBehaviour {

    public GameObject hexPrefab;

    public Material[] material;

    private static int width = 64;
    private static int height = 80;

    float xOffset = 0.882f;
    float yOffset = 0.764f;

	// Use this for initialization
	void Start () {
		for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {

                float xPos = x * xOffset;
                if (y % 2 == 1) {
                    xPos += xOffset / 2f;
                }
                GameObject hex_go = (GameObject) Instantiate(hexPrefab, new Vector3(xPos, 0, y * yOffset), Quaternion.identity);

                hex_go.name = "Hex_" + x + "_" + y;
                hex_go.GetComponent<hex>().x = x;
                hex_go.GetComponent<hex>().y = y;

                hex_go.transform.SetParent(this.transform);

                hex_go.GetComponent<hex>().setTerrain(TerrainEnumMethods.getRandomTerrain());
                hex_go.GetComponent<hex>().setGameObject(hex_go);

                hex_go.isStatic = true;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static int getWidth() {
        return width;
    }

    public static int getHeight() {
        return height;
    }
}
