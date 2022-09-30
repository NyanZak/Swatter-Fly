using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText, gameoverScoreText, gameoverHiScoreText;
    public float scoreCount, hiScoreCount;
    public float pointsPerSecond;
    public float scorePerWindow;

    private void Start()
    {
        scoreCount = 0f;
        pointsPerSecond = 1f;

        if (PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
    }

    private void Update()
    {
        if (scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);
        }
        scoreCount += pointsPerSecond * Time.deltaTime;
        scoreText.text = "Score: " +  (int)scoreCount;
        gameoverScoreText.text = "" + (int)scoreCount;
        gameoverHiScoreText.text = "" + (int)hiScoreCount;
    }

    public void windowScore()
    {
        scoreCount += scorePerWindow;
    }
}