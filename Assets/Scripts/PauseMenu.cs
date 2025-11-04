using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pausePanel;
    public static bool isPaused;
    
    void Start()
    {
        pausePanel.SetActive(false);
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                ResumeGame();
            }else{
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;   
        isPaused = false;
    }

    public void BackToMenu()
    {
        Debug.Log("Hallo1");
        Time.timeScale = 1f;  
        SceneManager.LoadScene("StartMenu"); 
        Debug.Log("Hallo2");
    } 
}
