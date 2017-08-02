using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private int highScore;
    private int coinsCollected = 0;

    public static ScoreManager instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        coinsCollected = score = highScore = 0;    
    }

    void Update()
    {
        CanvasManager.instance.setScoreText(score);
        CanvasManager.instance.SetCoinText(coinsCollected);
        //Debug.Log("Coin count: " + coinsCollected);
    }

    public void UpdateScore(int points)
    {
        score += points;

        if (score >= highScore)
        {
            UpdateHighScore(points);
        }

        UpdateCoinCount();
    }

    void UpdateCoinCount()
    {
        coinsCollected = CollectibleSpawner.instance.GetGemsCollected / 10;
    }

    void UpdateHighScore(int points)
    {
        highScore = points;
    }
}
