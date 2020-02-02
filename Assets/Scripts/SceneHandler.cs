using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void LoadMainMenu ()
    {
        SceneManager.LoadScene (0);
    }

    public void LoadFirstLevel ()
    {
        SceneManager.LoadScene (1);
    }
    
    public void LoadNextScene ()
    {
        int currencSceneIndex = SceneManager.GetActiveScene ().buildIndex;
        SceneManager.LoadScene (++currencSceneIndex);
    }

    public void LoadSceneByIndex (int index)
    {
        SceneManager.LoadScene (index);
    }

    public void LoadSceneByName ()
    {
        SceneManager.LoadScene(sceneName);
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
