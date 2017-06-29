using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private int highScore;

    private int comboStreak = 1;
    private int lastPrefabCollectedID;

    public static ScoreManager instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        score = highScore = 0;    
    }

    void Update()
    {
        CanvasManager.instance.setScoreText(score);
        //Debug.Log("Score: " + score);
    }

    public void UpdateScore(int points)
    {
        score += points;

        if (score >= highScore)
        {
            UpdateHighScore(points);
        }
    }

    void UpdateHighScore(int points)
    {
        highScore = points;
    }
}
