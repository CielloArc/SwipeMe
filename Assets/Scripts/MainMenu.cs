using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Awake()
    {
        //Screen.SetResolution(600, 800, false);
    }

    public void Play()
    {
        SceneManager.LoadScene("SceneGame");
    }
}
