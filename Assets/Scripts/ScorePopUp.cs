using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ScorePopUp : MonoBehaviour
{
    [FormerlySerializedAs ("scorePopUpCanvas")] [SerializeField] private GameObject scorePopUpGameObject;
    private Canvas scorePopUpCanvas;
    private float score = 10;
    private GameObject currentScore;
    private float scoreValue;
    //public static event System.Action<float> Scored;
    public static event System.Action<float> BetterScored;

    private void Start ()
    {
        scorePopUpCanvas = scorePopUpGameObject.GetComponent<Canvas> ();
        currentScore = GameObject.Find ("ScoreValue");
        scoreValue = 0;
    }

    private void Update ()
    {
        if (Input.GetKeyUp (KeyCode.P))
        {
            ShowScorePopUp ();
            IncrementScore ();
        }
    }

    public void ShowScorePopUp ()
    {
        print ("J=#)AWDJ=");
        //Scored.Invoke(score);
        BetterScored?.Invoke(score);
        scorePopUpCanvas.enabled = true;
        scorePopUpGameObject.GetComponentInChildren<TextMeshProUGUI> ().text = "+" + score.ToString ();
        StartCoroutine (nameof (DisableCanvasAfterDelay));
    }

    IEnumerator DisableCanvasAfterDelay ()
    {
        yield return new WaitForSeconds (1.0f);
        scorePopUpCanvas.enabled = false;
    }

    public void IncrementScore ()
    {
        scoreValue += score;
        currentScore.GetComponent<TextMeshProUGUI> ().text = scoreValue.ToString ();
    }
}
