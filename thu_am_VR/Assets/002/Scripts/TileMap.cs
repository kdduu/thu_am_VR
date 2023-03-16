using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    public GameObject TileQuad;
    public float TileSize = 1.0f;
    public enum TerrainEnum : int { GRASS,SAND,WATER,WALL}

    public TerrainEnum[,] map = 
        {
            {TerrainEnum.SAND,TerrainEnum.GRASS,TerrainEnum.WALL,TerrainEnum.WATER,TerrainEnum.SAND},
        };

    void Start()
    {
        for(int row = 0; row < map.GetLength(0); row++)
        {
            for(int column = 0; column < map.GetLength(1); column++)
            {
                GameObject Temp = (GameObject)instantiate(TileQuad);
                Temp.transform.position = new Vector3(column * TileSize,-row*TileSize,0);
                Temp.GetComponent<TileColor>().TileColorType = (TileColor.TerrainEnum)map[row, column];
            }
        }
    }

}
