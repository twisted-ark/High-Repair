using TMPro;
using UnityEngine;

public class ShowScoreAtEnd : MonoBehaviour
{
    [SerializeField] private TMP_Text text;


    private float displayedScore;
    
    private void Update ()
    {
        if (ScoreShowing.Score == displayedScore)
            return;

        displayedScore = ScoreShowing.Score;
        
        text.SetText ($"GAME OVER\nScore: {displayedScore.ToString()}");
    }
}
