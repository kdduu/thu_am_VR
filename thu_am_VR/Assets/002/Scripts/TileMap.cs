using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    public GameObject TileQuad;
    public enum TerrainEnum : int   
    {
        GRASS,
        SAND,
        WATER,
        WALL
    }

    public TerrainEnum[,] map =
    {
        {TerrainEnum.SAND , TerrainEnum.SAND, TerrainEnum.SAND,TerrainEnum.SAND,TerrainEnum.WALL },
        {TerrainEnum.GRASS , TerrainEnum.GRASS, TerrainEnum.WATER,TerrainEnum.SAND,TerrainEnum.WALL },
        {TerrainEnum.GRASS , TerrainEnum.GRASS, TerrainEnum.WATER,TerrainEnum.SAND,TerrainEnum.WALL },
        {TerrainEnum.GRASS , TerrainEnum.GRASS, TerrainEnum.WATER,TerrainEnum.SAND,TerrainEnum.WALL },
        {TerrainEnum.GRASS , TerrainEnum.GRASS, TerrainEnum.WATER,TerrainEnum.SAND,TerrainEnum.WALL },
        {TerrainEnum.SAND , TerrainEnum.SAND, TerrainEnum.WATER,TerrainEnum.WALL ,TerrainEnum.WALL },
        {TerrainEnum.SAND , TerrainEnum.SAND, TerrainEnum.WATER,TerrainEnum.WALL ,TerrainEnum.WALL },

        
    };

    // Start is called before the first frame update
    void Start()
    {
        for(int row = 0; row < map.GetLength(0); row++)
        {
            for(int column = 0; column < map.GetLength(1); column++)
            {
                GameObject Temp = (GameObject)Instantiate(TileQuad);
                Temp.transform.position = new Vector3(column, -row, 0);
                Temp.GetComponent<TileColor>().TileColorType = (TileColor.TerrainEnum)map[row, column];

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
