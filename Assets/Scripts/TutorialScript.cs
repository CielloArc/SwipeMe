using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    [SerializeField]
    private string nomeCena;
    [SerializeField]
    [Range(0.1f, 1f)]
    private float timeToWait = 0.5f;

    [SerializeField]
    private Image tutorialImage;

    [SerializeField]
    private Sprite[] uiSprites;

    private int spriteIndex = -1;

    void Start()
    {
        StartCoroutine(SwitchSprites());
    }

    public void Play()
    {        
        StartCoroutine(StartGame());
    }

    IEnumerator SwitchSprites()
    {
        while (true)
        {
            spriteIndex++;
            spriteIndex = spriteIndex % uiSprites.Length;
            tutorialImage.sprite = uiSprites[spriteIndex];
            yield return new WaitForSeconds(3.5f);
        }
        yield return null;
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene(nomeCena);
    }
}
