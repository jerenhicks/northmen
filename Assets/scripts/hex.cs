using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hex : MonoBehaviour {

    public int x;
    public int y;
    private GameObject gameObj;
    public Material[] material;
    private bool selected;
    private Color previousColor;
    private MapTile mapTile;

    // Use this for initialization
    void Start() {
        Renderer renderer = gameObject.GetComponentInChildren<Renderer>();
        previousColor = renderer.material.color;
    }

    // Update is called once per frame
    void Update() {

    }

    private void processTerrain() {
        if (this.mapTile.getTerrainType() == TerrainEnum.UNKNOWN || gameObj == null) {
            Renderer renderer = gameObject.GetComponentInChildren<Renderer>();
            if (renderer != null) {
                if ((int) this.mapTile.getTerrainType() > material.Length) {
                    Debug.LogError("hex.cs: Error while trying to map to material... Was not enough materials added to hex.cs. Verify material based on TerrainEnum.");
                }
                else {
                    renderer.material = material[(int)this.mapTile.getTerrainType()];
                }
            }
            else {
                Debug.Log("Map-- Had issue getting the renderer");
            }
        }
    }

    public TerrainEnum getTerrain() {
        return this.mapTile.getTerrainType();
    }

    public void setGameObject(GameObject gameObject) {
        this.gameObj = gameObject;
        this.processTerrain();
    }

    public GameObject getGameObject() {
        return this.gameObject;
    }

    public void select() {
        selected = true;
        Renderer renderer = gameObject.GetComponentInChildren<Renderer>();
        renderer.material.color = Color.red;
    }

    public void unselect() {
        selected = false;
        Renderer renderer = gameObject.GetComponentInChildren<Renderer>();
        renderer.material.color = previousColor;
    }

    public bool isSelected() {
        return this.selected;
    }

    public void setMapTile(MapTile tile) {
        this.mapTile = tile;
        this.processTerrain();
    }

    public MapTile getMapTile() {
        return this.mapTile;
    }
}
