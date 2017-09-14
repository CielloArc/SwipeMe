using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string nomeCena;

    [SerializeField]
    [Range(0.1f, 1f)]
    private float timeToWait = 0.5f;


    void Awake()
    {
        //Screen.SetResolution(600, 800, false);
    }

    public void Play()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene(nomeCena);
    }
}
