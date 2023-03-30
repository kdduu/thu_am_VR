using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorotineSystem : MonoBehaviour
{
    private Queue coroutineQueue = new Queue();

    public void AddCorutineQueue(IEnumerator coroutine)
    {
        coroutineQueue.Enqueue(coroutine);
    }

    void Start()
    {
        AddCorutineQueue(Logging(10));
        AddCorutineQueue(Logging(100));
        AddCorutineQueue(Logging(1000));
        if (coroutineQueue.Count>0)
        {
            StartCoroutine((IEnumerator)coroutineQueue.Dequeue());
        }
    }

    IEnumerator Logging (int number)
    {
        for(int i= number;i<number +10;i++)
        {
            Debug.Log(i.ToString() + "<---");
            yield return new WaitForSeconds(0.1f);
        }

        if(coroutineQueue.Count>0)
        {
            StartCoroutine((IEnumerator)coroutineQueue.Dequeue());
        }
    }
}
