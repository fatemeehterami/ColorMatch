using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using Unity.VisualScripting;


public class GameManager : MonoBehaviour
{
    public Image[] images;
    int[] arrayOfNums = { 0, 1, 2, 3, 4, 5, 6, 7 };
    Dictionary<string, Color> colors;
    public Color colorToPick;
    public int score;
    public int heart;
    public Text pickTxt;
    public Text scoreTxt;
    public Text heartTxt;
    public Button resetBtn;
    public Button startBtn;
    public GameObject gameOverBg;
    public GameObject startBg;
    public AudioClip correctSound;
    public AudioClip wrongSound;
    public AudioClip gameoverSound;
    private AudioSource audioSource;
    void Start()
    {
        colors = new Dictionary<string, Color>
        {
            { "blue", Color.blue },
            { "cyan", Color.cyan },
            { "gray", Color.gray },
            { "green", Color.green },
            { "magenta", Color.magenta },
            { "red", Color.red },
            { "white", Color.white },
            { "yellow", Color.yellow }
        };
        images = GetComponentsInChildren<Image>();
        audioSource = GetComponent<AudioSource>();
        resetBtn.onClick.AddListener(ResetGame);
        startBtn.onClick.AddListener(StartGame);
        heart = 3;
        setupcolor();
        setupText();
    }
    public void setupcolor()
    {
        images = GetComponentsInChildren<Image>();
        arrayOfNums = arrayOfNums.OrderBy(i => Random.Range(0, images.Length)).ToArray();
        int newNum = 0;
        foreach (Image img in images)
        {
            img.color = setColor(arrayOfNums[newNum]);
            newNum++;
        }

    }
    public void setupText()
    {
        int rand = Random.Range(0, colors.Count);
        pickTxt.text = "Click " + colors.ElementAt(rand).Key;
        colorToPick = colors.ElementAt(rand).Value;
        pickTxt.color = setColor(Random.Range(0, 7));
        scoreTxt.text = "Score: " + score;
        heartTxt.text = "Live: " + heart;
    }
    public Color setColor(int numInArray)
    {
        switch (numInArray)
        {
            case 0:
                return Color.blue;
            case 1:
                return Color.cyan;
            case 2:
                return Color.gray;
            case 3:
                return Color.green;
            case 4:
                return Color.magenta;
            case 5:
                return Color.red;
            case 6:
                return Color.white;
            case 7:
                return Color.yellow;
            default:
                return Color.clear;

        }
    }
    public void checkColor(Image image)
    {
        if (image.color == colorToPick)
        {
            setupcolor();
            setupText();
            score++;
            scoreTxt.text = "Score: " + score;
            PlaySound(correctSound);
        }
        else
        {
            heart--;
            score--;
            PlaySound(wrongSound);
            if (heart == 0)
            {
                GameOver();
                PlaySound(gameoverSound);
            }
            else
            {
                heartTxt.text = "Live: " + heart;
            }
        }
    }
    void GameOver()
    {
        gameOverBg.SetActive(true);

    }
    void ResetGame()
    {
        gameOverBg.SetActive(false);
        startBg.SetActive(true);
        heart = 3;
        score = 0;
        scoreTxt.text = "Score: " + score;
        setupcolor();
        setupText();
    }
    void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
    void StartGame()
    {
        startBg.SetActive(false);
        heart = 3;
        score = 0;
        setupcolor();
        setupText();
    }

}
