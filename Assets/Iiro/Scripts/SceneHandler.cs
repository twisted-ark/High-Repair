﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void LoadNextScene ()
    {
        int currencSceneIndex = SceneManager.GetActiveScene ().buildIndex;
        SceneManager.LoadScene (++currencSceneIndex);
    }

    public void LoadSceneByIndex (int index)
    {
        SceneManager.LoadScene (index);
    }

    public void QuitGame ()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}