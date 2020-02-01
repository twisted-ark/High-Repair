using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStateManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject runTimeCanvas;
    
    public void Pause ()
    {
        Time.timeScale = 0;
        runTimeCanvas.GetComponent<Canvas> ().enabled = false;
        pauseCanvas.GetComponent<Canvas> ().enabled = true;
    }

    public void GameOver ()
    {
        Time.timeScale = 0;
        runTimeCanvas.GetComponent<Canvas> ().enabled = false;
        gameOverCanvas.GetComponent<Canvas> ().enabled = true;
    }

    public void Resume ()
    {
        Time.timeScale = 1;
        pauseCanvas.GetComponent<Canvas> ().enabled = false;
        runTimeCanvas.GetComponent<Canvas> ().enabled = true;
    }
}
