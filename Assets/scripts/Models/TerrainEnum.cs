using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum TerrainEnum { 
    UNKNOWN,
    GRASS,
    ROCK,
    SHALLOW_WATER,
    DEEP_WATER
}

static class TerrainEnumMethods {

    private static System.Random random = new System.Random();

    public static TerrainEnum getRandomTerrain() {
        TerrainEnum[] values = (TerrainEnum[])Enum.GetValues(typeof(TerrainEnum));
        return values[random.Next(0, values.Length)];

    }

    public static int amount() {
        return Enum.GetNames(typeof(TerrainEnum)).Length;
    }
}

