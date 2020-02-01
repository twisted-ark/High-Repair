using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vcam;
    [FormerlySerializedAs ("vcam2")] [SerializeField] private CinemachineVirtualCamera vcamWithShaking;
    [SerializeField] private float timeBetweenQuakes = 10;
    private float time;

    private void Update ()
    {
        time += Time.deltaTime;
        
        if (time >= timeBetweenQuakes)
        {
            vcam.enabled = false;
            vcamWithShaking.enabled = true;
            StartCoroutine (nameof (StopCameraShakeAfterDelay));
            time = 0;
        }
    }

    IEnumerator StopCameraShakeAfterDelay ()
    {
        yield return new WaitForSeconds (2);
        vcamWithShaking.enabled = false;
        vcam.enabled = true;
    }
}
