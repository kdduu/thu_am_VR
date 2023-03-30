using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemies : MonoBehaviour
{
    public float jumpForce = 5f;
    public float jumpInterval = 1f;

    private Queue<GameObject> enemyQueue = new Queue<GameObject>();

    void Start()
    {
        StartCoroutine(SetJumpEnemies());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AddEnemyToQueue();
        }
    }

    void AddEnemyToQueue()
    {
        GameObject enemy = GameObject.CreatePrimitive(PrimitiveType.Cube);
        enemy.transform.position = new Vector3(Random.Range(-5, 5), 0.5f, Random.Range(-5, 5));
        enemy.AddComponent<Rigidbody>();
        enemyQueue.Enqueue(enemy);
    }

    IEnumerator SetJumpEnemies()
    {
        while(true)
        {
            if(enemyQueue.Count>0)
            {
                GameObject enemy = enemyQueue.Dequeue();
                Rigidbody rb = enemy.GetComponent<Rigidbody>();
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                yield return new WaitForSeconds(jumpInterval);

                Destroy(enemy);
            }
            yield return null;
        }
    }
}
