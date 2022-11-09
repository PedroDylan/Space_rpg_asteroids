using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torus : MonoBehaviour
{
    float leftConstraint = Screen.width;
    float rightConstraint = Screen.width;
    float bottomConstraint = Screen.height;
    float topConstraint = Screen.height;
    float buffer = 1f;
    float distanceZ;

    Camera cam;


    void Start()
    {
        cam = Camera.main;
        distanceZ = Mathf.Abs(cam.transform.position.z + transform.position.z);
        leftConstraint = cam.ScreenToWorldPoint(new Vector3(0,0,distanceZ)).x;
        rightConstraint = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, distanceZ)).x;
        bottomConstraint = cam.ScreenToWorldPoint(new Vector3(0, 0, distanceZ)).y;
        topConstraint = cam.ScreenToWorldPoint(new Vector3(0, Screen.height, distanceZ)).y;
    }

    private void FixedUpdate()
    {
        if(transform.position.x < leftConstraint - buffer)
        {
            transform.position = new Vector3(rightConstraint+buffer,transform.position.y,transform.position.z);
        }
        if (transform.position.x > rightConstraint + buffer)
        {
            transform.position = new Vector3(leftConstraint-buffer,transform.position.y,transform.position.z);
        }
        if(transform.position.y < bottomConstraint - buffer)
        {
            transform.position = new Vector3(transform.position.x,topConstraint+buffer,transform.position.z);
        }
        if(transform.position.y > topConstraint + buffer)
        {
            transform.position = new Vector3(transform.position.x, bottomConstraint - buffer, transform.position.z);
        }
    }
}
