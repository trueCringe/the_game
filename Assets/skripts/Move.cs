using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 10f;
    public float rspeed = 60f;
    private float horizontal;
    private float vertical;
    public GameMananger gameMananger;
    public float maxspeed = 35f;
    public float acceleration = 20f;
    public float deceleration = 10f;
    public float maxReversSpeed = -20f;
    private Vector3 startPosition;
    private Quaternion startRotation;
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.W))
        //{ transform.Translate(Vector3.forward * Time.deltaTime * speed); }
        //if (Input.GetKey(KeyCode.S))
        //{ transform.Translate(Vector3.back * Time.deltaTime * speed); }
        //if (Input.GetKey(KeyCode.A))
        //{ transform.Rotate(Vector3.up * Time.deltaTime * (-rspeed)); }
        //if (Input.GetKey(KeyCode.D))
        //{ transform.Rotate(Vector3.up * Time.deltaTime * rspeed); }
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (vertical > 0)
        {
            speed = Mathf.MoveTowards(speed, maxspeed, acceleration * Time.deltaTime);
        }
        else if (vertical < 0)
        {
            speed = Mathf.MoveTowards(speed, maxReversSpeed, acceleration * Time.deltaTime);
        }
        else
        { speed = Mathf.MoveTowards(speed, 0, deceleration * Time.deltaTime); }
        transform.Translate(Vector3.forward * speed * Time.deltaTime * vertical);
        transform.Rotate(Vector3.up * horizontal * rspeed * Time.deltaTime);

        if (OutOfBounds() || Input.GetKeyDown(KeyCode.Escape))
        {
            Reset();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("chekpoint"))
        {
            Debug.Log("Chek!" + other.name);
            gameMananger.ChekpointEnd(other.gameObject);

        }
        if (other.CompareTag("Finish"))
        {
            Debug.Log("finish!");
            gameMananger.FinishEnd(other.gameObject);
        }
    }

    private bool OutOfBounds()
    {
        if (transform.position.y < -3)
            return true;
        else
            return false;
    }
    private void Reset()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
        speed = 0;
    }
}
