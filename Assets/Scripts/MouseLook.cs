using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public int sens = 600;
    public Transform body;
    float xRot = 0f;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update() {
        
        float rotX = Input.GetAxisRaw("Mouse X") * sens * Time.deltaTime;
        float rotY = Input.GetAxisRaw("Mouse Y") * sens * Time.deltaTime;

        xRot -= rotY;
        xRot = Mathf.Clamp(xRot, -80f,80f);

        transform.localRotation = Quaternion.Euler(xRot,0f,0f);
        
        body.Rotate(Vector3.up*rotX);
    }
}