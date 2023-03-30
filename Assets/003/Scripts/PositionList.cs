using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PositionList : MonoBehaviour
{
    public List<Vector3> positionList;
    public List<Vector3> filter_PositionList;

    void Start()
    {
        LINQFunction();
    }

    public void LINQFunction()
    {
        filter_PositionList = new List<Vector3>();

        filter_PositionList = positionList
            .Where(n => Vector3.Distance(transform.position, n) > 2f)
            .OrderBy(n => Vector3.Distance(transform.position, n))
            .ToList();
    }
}
