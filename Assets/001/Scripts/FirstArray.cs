using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstArray : MonoBehaviour
{
    public int[] number = new int[] { 9, -11, 6, -12, 1 };
    void Start()
    {
        number[1] = 11;
        number[2] = 12;
        Debug.Log(number[0]);
    }

}
