using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class MapController : MonoBehaviour {

    public static MapController controller = null;
    public GameObject hexPrefab;

    public Material[] material;

    private static int width = 64;
    private static int height = 80;

    float xOffset = 0.882f;
    float yOffset = 0.764f;

    private MapItem mapContainer;

    void Awake() {
        controller = this;
    }

    // Use this for initialization
    void Start () {

        //this just creates a random thing here.
        mapContainer = new MapItem();
        mapContainer.height = 64;
        mapContainer.width = 80;
        mapContainer.tiles = new List<MapTile>();
        for (int x = 0; x < 64 * 80; x++) {
            MapTile tile = new MapTile();
            tile.terrainType = "Grass";
            mapContainer.tiles.Add(tile);
        }


        createMap();

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

    private void createMap() {
        int count = 0;
        for (int x = 0; x < mapContainer.width; x++) {
            for (int y = 0; y < mapContainer.height; y++) {

                float xPos = x * xOffset;
                if (y % 2 == 1) {
                    xPos += xOffset / 2f;
                }
                GameObject hex_go = (GameObject)Instantiate(hexPrefab, new Vector3(xPos, 0, y * yOffset), Quaternion.identity);

                hex_go.name = "Hex_" + x + "_" + y;
                hex_go.GetComponent<hex>().x = x;
                hex_go.GetComponent<hex>().y = y;

                hex_go.transform.SetParent(this.transform);

                MapTile tile = mapContainer.tiles[count];
                TerrainEnum terrainType = (TerrainEnum)System.Enum.Parse(typeof(TerrainEnum), tile.terrainType, true);
                hex_go.GetComponent<hex>().setTerrain(terrainType);
                hex_go.GetComponent<hex>().setGameObject(hex_go);

                hex_go.isStatic = true;
                count++;
            }
        }
    }

    public void loadMapFromFile() {
        clearMap();
        TextAsset asset = Resources.Load("map1") as TextAsset;
        MapItem m = JsonUtility.FromJson<MapItem>(asset.text);
        mapContainer = m;
        createMap();
    }

    public void clearMap() {
        foreach (hex o in Object.FindObjectsOfType<hex>()) {
            Destroy(o.gameObject);
        }

    }
}
