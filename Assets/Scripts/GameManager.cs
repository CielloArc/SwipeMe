using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool gameEnd = false;

    public bool hasGameEnded{ get { return gameEnd; } }

    private bool hasBeenPaused = false;

    void Awake()
    {
        //Screen.SetResolution(600, 800, false);
        if (instance == null)
            instance = this;
       

        Invoke("StartGame", 5);
    }

    void StartGame()
    {
        gameEnd = false;
        Debug.Log("Game Started");
    }

    public void PauseGame()
    {
        hasBeenPaused = !hasBeenPaused;
        Time.timeScale = hasBeenPaused ? 0f : 1f;
        CanvasManager.instance.PauseCanvas(hasBeenPaused);
    }

    public void EndGame()
    {
        gameEnd = true;
        CanvasManager.instance.GameOverCanvas();
    }

    public void Retry()
    {
        if (ScoreManager.instance.Coins > 4)
        {
            AudioManager.instance.Play("ButtonTouch");
            PlayerPrefs.SetInt("Retry", 1);
            ScoreManager.instance.PayCoin(5);
            Invoke("Reload", .5f);
        }
    }

    public void PlayAgain()
    {
        AudioManager.instance.Play("ButtonTouch");
        PlayerPrefs.SetInt("Retry", 0);
        Invoke("Reload", .5f);
    }

    public void Quit()
    {
        AudioManager.instance.Play("ButtonTouch");
        Application.Quit();
    }


    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    #region AD_REGION

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }

    #endregion
}
