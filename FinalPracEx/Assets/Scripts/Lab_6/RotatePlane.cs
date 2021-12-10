using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlane : MonoBehaviour
{
    public GameObject fallingBall;
    private Quaternion defaultRotation;
    private Vector3 defaultBallPosition, defaultBallVelocity,
        defaultBallAngularVelocity;
    private Rigidbody rb;

    public GameObject movingBall;
    private Quaternion defaultRotation2;
    private Vector3 defaultBallPosition2, defaultBallVelocity2,
        defaultBallAngularVelocity2;
    private Rigidbody rb2;

    // Start is called before the first frame update
    void Start()
    {
        rb = fallingBall.GetComponent<Rigidbody>();
        defaultBallPosition = rb.transform.position;
        defaultBallVelocity = rb.velocity;
        defaultBallAngularVelocity = rb.angularVelocity;
        defaultRotation = transform.rotation;

        rb2 = movingBall.GetComponent<Rigidbody>();
        defaultBallPosition2 = rb2.transform.position;
        defaultBallVelocity2 = rb2.velocity;
        defaultBallAngularVelocity2 = rb2.angularVelocity;
        defaultRotation2 = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("r"))
        {
            fallingBall.SetActive(true);
            transform.rotation = defaultRotation;
            rb.transform.position = defaultBallPosition;
            rb.velocity = defaultBallVelocity;
            rb.angularVelocity = defaultBallAngularVelocity;

            movingBall.SetActive(true);
            transform.rotation = defaultRotation2;
            rb2.transform.position = defaultBallPosition2;
            rb2.velocity = defaultBallVelocity2;
            rb2.angularVelocity = defaultBallAngularVelocity2;
        }
        if (Input.GetKeyDown("="))
        {
            transform.Rotate(new Vector3(0, 0, 1), -2);
        }else if (Input.GetKeyDown("-"))
        {
            transform.Rotate(new Vector3(0, 0, 1), 2);
        }
    }
}
