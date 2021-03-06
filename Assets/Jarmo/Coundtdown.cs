﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coundtdown : MonoBehaviour
{
    public float startTime;
    public float currentTime;
    public float GameTime = 60;
    [SerializeField] private TMP_Text text;

    public UIStateManager uIStateManager;


    private void Awake ()
    {
        //startTime = Time.time;
    }

    private void Update ()
    {
        GameTime -= Time.deltaTime;


        text.text = GameTime.ToString("f1"); //Mathf.RoundToInt(currentTime).ToString();

        if (GameTime <= 0)
        {
            uIStateManager.GameOver();
            Debug.Log("END");
        }
    }
}
