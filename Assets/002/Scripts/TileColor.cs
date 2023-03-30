using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColor : MonoBehaviour //타일 오브젝트에 쓰일 클래스(Prefabs)
{
    Renderer rend; //랜더러를 가져온다.

    public enum TerrainEnum : int  // 숫자로 타일을 구분하기 위해서 (int) 
    {
        GRASS,
        SAND,
        WATER,
        WALL
    }

    public TerrainEnum TileColorType;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

        if (TileColorType == TerrainEnum.GRASS)
            rend.material.SetColor("_Color", Color.green);
        if (TileColorType == TerrainEnum.SAND)
            rend.material.SetColor("_Color", Color.yellow);
        if (TileColorType == TerrainEnum.WATER)
            rend.material.SetColor("_Color", Color.blue);
        if (TileColorType == TerrainEnum.WALL)
            rend.material.SetColor("_Color", Color.grey);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
