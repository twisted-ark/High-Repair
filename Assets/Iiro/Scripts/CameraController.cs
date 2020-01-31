using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 position;
    
    private void Start ()
    {
        position = transform.position;
    }
    
    private void Update ()
    {
        if (Input.GetKeyUp (KeyCode.Space))
        {
            Debug.Log ("Pressed Space Key");
            RaiseCamera ();
        }
    }
    
    private void RaiseCamera ()
    {
        Debug.Log ("Inside RaiseCamera function.");
        position.y += 1;
        Camera.main.transform.position = position;
    }
}
