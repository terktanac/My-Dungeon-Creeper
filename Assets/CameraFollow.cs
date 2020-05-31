using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float yThreshold = 2;
    public Vector3 cameraVelocity = new Vector3(0,5,0);
    public float smoothTime = 0.5f;

    private Vector3 targetPos;
    private float yPos;
    private float xPos;
    private float zPos;
    private float lastYPos;
    private bool isMoveBeyond = false;

    // Start is called before the first frame update
    void Start()
    {
        xPos = transform.position.x;
        zPos = transform.position.z;
        lastYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {   
        targetPos = target.position;
        yPos = targetPos.y;
        float yDiff = Math.Abs(yPos - lastYPos);

        if (yDiff >= yThreshold) {
            isMoveBeyond = true;
            lastYPos = yPos;
        }
    }

    void FixedUpdate() 
    {
        if (isMoveBeyond){
            Vector3 newPos = new Vector3(xPos, yPos, zPos);
            transform.position = Vector3.SmoothDamp(transform.position, newPos, ref cameraVelocity, smoothTime);
            isMoveBeyond = false;
        }
    }
}
