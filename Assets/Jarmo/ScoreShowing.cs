using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreShowing : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    public float value;

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
    }

}
