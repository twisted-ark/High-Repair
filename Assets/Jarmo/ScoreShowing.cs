using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreShowing : MonoBehaviour
{
    public static float Score;
    
    [SerializeField] private TMP_Text text;
    public float value;

    private void Awake ()
    {
        Score = 0;
    }

    private void OnEnable()
    {
        ScorePopUp.BetterScored += UpdateText;
    }

    private void OnDisable()
    {
        ScorePopUp.BetterScored -= UpdateText;
    }

    private void UpdateText(float score)
    {
        value += score;
        text.text = value.ToString();
        Score = value;
    }

}
