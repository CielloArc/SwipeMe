using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CanvasManager : MonoBehaviour
{

    [Header("Canvas GameObjects")]
    public GameObject GameHud;
    public GameObject GameOverHUD;


    [Header("HUD ELEMENTS")]
    public Text scoreText;
    public Text comboStreakText;
    public FloatingCanvas[] fCanvas;

    public static CanvasManager instance;

    void Start()
    {
        if (instance == null)
            instance = this;

        GameHud.SetActive(true);
        GameOverHUD.SetActive(false);
    }

    void Update()
    {
		
    }

    public void setScoreText(int points)
    {
        scoreText.text = "SCORE: " + points;
    }

    public void setComboStreakText(int comboStreak)
    {
        comboStreakText.text = "COMBO STREAK: " + comboStreak + "X";
    }

    public void InstantiateFloatingObject(int canvasType, Transform location)
    {  

        Vector2 screenPostion = Camera.main.WorldToScreenPoint(location.position);

        switch (canvasType)
        {
            case 1:
                FloatingCanvas fObject = Instantiate(fCanvas[0]);
                fObject.transform.SetParent(this.transform, false);
                fObject.transform.position = screenPostion;
                break;
            case 2:
                fObject = Instantiate(fCanvas[1]);
                fObject.transform.SetParent(this.transform, false);
                fObject.transform.position = screenPostion;
                break;                
        }
    }

    public void GameOverCanvas()
    {
        GameHud.SetActive(false);
        GameOverHUD.SetActive(true);

    }
}
