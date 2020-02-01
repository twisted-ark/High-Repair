using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This script should be added to Main Camera Game Object

public class CameraController : MonoBehaviour
{
    [SerializeField] private float heightIncrease = 1.0f;
    [SerializeField] private float deltaY = 0.05f;

    private void Update ()
    {
        if (Input.GetKeyUp (KeyCode.Space))
        {
            Debug.Log ("Pressed Space");
            RaiseCameraSmoothly ();
        }
    }

    public void RaiseCameraSmoothly ()
    {
        StartCoroutine (Translate ());
    }

    IEnumerator Translate()
    {
        float t = 0.0f;
        
        while (t < heightIncrease)
        {
            transform.Translate (0, deltaY,0);
            t += deltaY;
            yield return null;
        }
    }
}
