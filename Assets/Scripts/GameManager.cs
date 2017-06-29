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

    public void EndGame()
    {
        gameEnd = true;
        CanvasManager.instance.GameOverCanvas();
    }

    public void Retry()
    {
        AudioManager.instance.Play("ButtonTouch");
        Invoke("Reload", .5f);
    }

    public void MainMenu()
    {
        AudioManager.instance.Play("ButtonTouch");
        SceneManager.LoadScene("SceneMenu");
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
