using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    public static bool isOver;
    
    void Start()
    {
        gameOver.SetActive(false);
    }

   
    void Update()
    {
        if(PlayerHealth.currentHealth <= 0){
            RestartButton();
        }      
    }

    public void RestartButton()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0f;
        isOver = true;
        
        
        if (PauseMenu.instance != null) 
        {
            PauseMenu.instance.pausePanel.SetActive(false);
        }
    }
}
