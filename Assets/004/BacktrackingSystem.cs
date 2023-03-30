using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacktrackingSystem : MonoBehaviour
{
    private Stack<Vector3> positionStack = new Stack<Vector3>();

    public float speed = 5f;

    private Rigidbody rb;
    public float checkTime = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Backspace))
        {
            if(positionStack.Count > 0)
            {
                Vector3 prevPos = positionStack.Pop();
                transform.position = prevPos;
            }
        }
        checkTime += Time.deltaTime;

        if(checkTime > 0.2f)
        {
            Vector3 currPos = transform.position;
            positionStack.Push(currPos);
            checkTime = 0.0f;
        }
    }
    
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }
        rb.velocity = movement.normalized * speed;
    }
}
