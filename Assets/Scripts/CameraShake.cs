using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private float timeBetweenQuakes = 10;
    private float time;
    private CinemachineVirtualCamera vcam;
    private CinemachineBasicMultiChannelPerlin noise;
    private float amplitudeGain = 2;
    [SerializeField] private Explosion earthquake;

    private void Start ()
    {
        time = timeBetweenQuakes;
        //noise.m_AmplitudeGain = 0;
        vcam = mainCamera.GetComponent<CinemachineVirtualCamera> ();
        noise = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin> ();
    }

    private void Update ()
    {
        time += Time.deltaTime;
        
        if (time >= timeBetweenQuakes)
        {
            earthquake.Quake ();

            noise.m_AmplitudeGain = amplitudeGain;

            StartCoroutine (nameof (StopCameraShakeAfterDelay));
            time = 0;
        }
    }

    IEnumerator StopCameraShakeAfterDelay ()
    {
        yield return new WaitForSeconds (2);
        
        noise.m_AmplitudeGain = 0;
    }
}
