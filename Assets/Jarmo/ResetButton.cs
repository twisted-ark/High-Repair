using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    private void OnEnable()
    {
        ControllableBox.Fail += ReloadScene;
    }

    private void OnDisable()
    {
        ControllableBox.Fail -= ReloadScene;
    }

    public void ReloadScene ()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene().name);
    }
}