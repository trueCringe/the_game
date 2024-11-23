using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int apes = 2;
    public float speed = 1.0f; // целое и не целое числа
    private bool gameActive = true;
    void Start()
    {
        Debug.Log("hi from start");
        if (gameActive==true) {
            apes += 20;
           // speed *= 10;
        }

    }

    

    void Update()
    {
        Debug.Log("hi from update");
        transform.position += new Vector3(0, 0, 1) * speed*Time.deltaTime;
    }
}
