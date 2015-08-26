﻿using UnityEngine;

//[AddComponentMenu("Camera-Control/Mouse drag Orbit with zoom")]
public class MouseOrbitCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;

    public float smoothTime = 2f;

    float rotationYAxis;
    float rotationXAxis;

    float velocityX;
    float velocityY;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        rotationYAxis = angles.y;
        rotationXAxis = angles.x;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            //Camera.main.transform.RotateAround(Vector3.zero, Vector3.up, 2000 * Input.GetAxis("Mouse X") * Time.deltaTime);
        }
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            velocityX += xSpeed * Input.GetAxis("Mouse X") * 0.02f;
            velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.02f;
        }

        rotationYAxis += velocityX;
        rotationXAxis -= velocityY;

        Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
        Quaternion rotation = toRotation;

        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 position = rotation * negDistance + target.position;

        transform.rotation = rotation;
        transform.position = position;

        velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
        velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);
    }
}
