using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapTile {

    public string terrainType;

    public void setTerrainType(string terrainType) {
        this.terrainType = terrainType;
    } 

    public string getTerrainTypeAsString() {
        return this.terrainType;
    }

    public TerrainEnum getTerrainType() {
        return (TerrainEnum)System.Enum.Parse(typeof(TerrainEnum), this.terrainType, true); ;
    }
}
