using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackReverse : MonoBehaviour
{

    Stack<int> stackNumber = new Stack<int>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i<10; i++)
        {
            stackNumber.Push(i);
        }
        string temp = "";

        while(stackNumber.Count>0)
        {
            temp += stackNumber.Pop().ToString() + "/";
        }

        Debug.Log(temp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
