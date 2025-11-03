using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private int highScore = 0;
    
    [SerializeField] private TextMeshProUGUI highScoreTextDisplay;
    [SerializeField] private TextMeshProUGUI scoreTextDisplay;
    
    private const string HighScoreKey = "HighScore";

    void Start()
    {
        highScore = PlayerPrefs.GetInt(HighScoreKey, 0); 

        UpdateHighScoreDisplay();
        Enemy.OneEnemyKilled += AddScore;
        UpdateScoreDisplay(); 
    }

    void OnDestroy()
    {
        Enemy.OneEnemyKilled -= AddScore;
    }

    public void AddScore(int scoreIncrease)
    {
        score += scoreIncrease; 
        UpdateScoreDisplay();
        CheckHighScore();
        
        //Debug.Log("Score erhöht durch Event: " + score);
    }
    
    private void UpdateScoreDisplay()
    {
        if (scoreTextDisplay != null)
        {
            scoreTextDisplay.text = "Score: " + score.ToString(); 
        }
    }

    private void CheckHighScore()
    {
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(HighScoreKey, score);
            PlayerPrefs.Save();
            UpdateHighScoreDisplay();
            Debug.Log("Neuer Highscore gespeichert: " + highScore);
        }
    }

    private void UpdateHighScoreDisplay()
    {
        if (highScoreTextDisplay != null)
        {
            highScoreTextDisplay.text = $"Highscore: {highScore}";
        }
    }
}