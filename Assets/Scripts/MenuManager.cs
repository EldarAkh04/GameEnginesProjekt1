using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnStartClick()
    {
        Time.timeScale = 1f; 
        PauseMenu.isPaused = false;
        GameOver.isOver = false;

        SceneManager.LoadScene("SampleScene");
    }

    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void OnTutorialClick()
    {
        if (Tutorial.instance != null)
        {
            Tutorial.instance.ShowTutorial();
        }
    }
    
    public void OnCloseTutorial()
    {
        if (Tutorial.instance != null)
        {
            Tutorial.instance.LeaveTuorial();
        }
    }
}