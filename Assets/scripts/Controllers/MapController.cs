using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class MapController : MonoBehaviour {

    public static MapController instance = null;
    private GameObject hexPrefab;
    private Material[] material;
    private int width;
    private int height;
    private float xOffset = 0.882f;
    private float yOffset = 0.764f;
    private Map mapContainer;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public int getWidth() {
        return width;
    }

    public int getHeight() {
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

                if (hexPrefab == null) {
                    Debug.Log("HexPrefab is null");
                }
                GameObject hex_go = (GameObject)Instantiate(hexPrefab, new Vector3(xPos, 0, y * yOffset), Quaternion.identity);

                hex_go.name = "Hex_" + x + "_" + y;
                hex_go.GetComponent<hex>().x = x;
                hex_go.GetComponent<hex>().y = y;

                GameObject test = GameObject.Find("Map");
                if (test == null) {
                    Debug.Log("Map object not found, failing out");
                    return;
                }

                hex_go.transform.SetParent(test.transform);

                MapTile tile = mapContainer.tiles[count];
                hex_go.GetComponent<hex>().setMapTile(tile);
                hex_go.GetComponent<hex>().setGameObject(hex_go);

                hex_go.isStatic = true;
                count++;
            }
        }
    }

    public void setTerrainMaterials(Material[] materials) {
        material = materials;
    }

    public void setPrefab(GameObject prefab) {
        Debug.Log("Prefab being set");
        if (prefab == null) {
            Debug.Log("Prefab is null....");
        }
        hexPrefab = prefab;
    }

    public void loadStaticMap() {
        //this just creates a random thing here.
        mapContainer = new Map();
        mapContainer.height = 64;
        mapContainer.width = 80;
        mapContainer.tiles = new List<MapTile>();
        for (int x = 0; x < 64 * 80; x++) {
            MapTile tile = new MapTile();
            tile.setTerrainType("Grass");
            mapContainer.tiles.Add(tile);
        }


        createMap();
    }

    public void loadMapFromFile() {
        clearMap();
        TextAsset asset = Resources.Load("map1") as TextAsset;
        Map m = JsonUtility.FromJson<Map>(asset.text);
        this.width = m.width;
        this.height = m.height;
        mapContainer = m;
        createMap();
    }

    public void clearMap() {
        foreach (hex o in Object.FindObjectsOfType<hex>()) {
            Destroy(o.gameObject);
        }
    }
}
