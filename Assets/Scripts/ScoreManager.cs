using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private int highScore;
    private int totalCoins;

    public static ScoreManager instance;

    public int HighScore { get { return highScore; } }

    public int Score { get { return score; } }

    public int Coins { get { return totalCoins; } }

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        GetInfo();       
        UpdateScoreText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteKey("HighScore");
            PlayerPrefs.DeleteKey("Coins");

            totalCoins = 0;
            highScore = 0;
        }
    }

    void UpdateScoreText()
    {
        CanvasManager.instance.setScoreText(score);
    }

    public void UpdateScore(int points)
    {
        score += points;
        PlayerPrefs.SetInt("Score", score);

        UpdateHighScore();
        UpdateCoinCount();
        UpdateScoreText();
    }

    public void PayCoin(int value)
    {
        totalCoins -= value;
        PlayerPrefs.SetInt("Coins", totalCoins);
    }

    void UpdateCoinCount()
    {
        if (CollectibleSpawner.instance.GetGemsCollected > 0 && CollectibleSpawner.instance.GetGemsCollected % 10 == 0)
        {            
            totalCoins += 1;
            //Debug.Log("TotalCoins:" + totalCoins);
            PlayerPrefs.SetInt("Coins", totalCoins);
        }
    }

    void UpdateHighScore()
    {   
        if (score >= highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    void GetInfo()
    {
        //Get HighScore
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            highScore = 0;
        }

        //Get coins
        if (PlayerPrefs.HasKey("Coins"))
        {
            totalCoins = PlayerPrefs.GetInt("Coins");
        }
        else
        {
            totalCoins = 0;
        }

        //GetScore if possible
        int retryValue = PlayerPrefs.GetInt("Retry", 0);

        if (retryValue == 1)
        {
            score = PlayerPrefs.GetInt("Score");
        }
        else
        {
            score = 0;
            PlayerPrefs.SetInt("Score", score);
        }

    }
}
