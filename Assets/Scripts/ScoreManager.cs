using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
   private int score = 0; 
   [SerializeField] private TextMeshProUGUI scoreTextDisplay;

    void Start()
    {
        Enemy.OnEnemyKilled += AddScore;
        UpdateScoreDisplay(); 
    }

    void OnDestroy()
    {
        Enemy.OnEnemyKilled -= AddScore;
    }

    public void AddScore(int scoreIncrease)
    {
        score += scoreIncrease; 
        UpdateScoreDisplay();
        Debug.Log("Score erhöht durch Event: " + score);
    }
    
    private void UpdateScoreDisplay()
    {
        if (scoreTextDisplay != null)
        {
            scoreTextDisplay.text = "Score: " + score.ToString(); 
        }
    }
}