using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CanvasManager : MonoBehaviour
{

    [Header("Canvas GameObjects")]
    public GameObject GameHud;
    public GameObject pauseHud;
    public GameObject GameOverHUD;


    [Header("HUD ELEMENTS")]
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text comboStreakText;
    [SerializeField]
    private FloatingCanvas[] fCanvas;
    [SerializeField]
    private Image soundButtonImage;
    [SerializeField]
    private Text gameOverScoreText;
    [SerializeField]
    private Text gameOverHighScoreText;
    [SerializeField]
    private Text gameOverCoins;
    [SerializeField]
    private Image diamondFillImage;

    [Header("Parameters")]
    [SerializeField]
    private Sprite[] soundButtonSprites;
    [SerializeField]
    private Color32[] diamondFillColor;

    public static CanvasManager instance;

    void Start()
    {
        if (instance == null)
            instance = this;

        GameHud.SetActive(true);
        GameOverHUD.SetActive(false);
        pauseHud.SetActive(false);
    }

    void Update()
    {
		
    }

    public void setScoreText(int points)
    {
        scoreText.text = points.ToString();
    }


    public void SetGameOverScoreText()
    {
        gameOverScoreText.text = ScoreManager.instance.Score.ToString();
        gameOverHighScoreText.text = ScoreManager.instance.HighScore.ToString();
        gameOverCoins.text = ScoreManager.instance.Coins.ToString();
    }

    public void setComboStreakText(int comboStreak)
    {
        comboStreakText.text = "x" + comboStreak;
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

    public void SwapSoundIcon(bool status)
    {
        soundButtonImage.sprite = status ? soundButtonSprites[0] : soundButtonSprites[1];
    }

    public void GameOverCanvas()
    {
        SetGameOverScoreText();
        GameHud.SetActive(false);
        GameOverHUD.SetActive(true);
    }

    public void PauseCanvas(bool status)
    {
        GameHud.SetActive(!status);
        pauseHud.SetActive(status);
    }

    public void FillDiamondImage(int value, EColor color)
    {
        diamondFillImage.color = SelectColor(color);
        diamondFillImage.fillAmount = (float)value / 10;
    }

    private Color SelectColor(EColor color)
    {
        switch (color)
        {
            case EColor.RED:
                return diamondFillColor[0];
            case EColor.GREEN:
                return diamondFillColor[1];
            case EColor.BLUE:
                return diamondFillColor[2];
            case EColor.WHITE:
                return diamondFillColor[3];
            case EColor.RAINBOW:
                return diamondFillColor[4];
            default:
                return diamondFillColor[0];
        }
    }
}
