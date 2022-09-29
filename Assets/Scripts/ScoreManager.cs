using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public float scoreCount;
    public float pointsPerSecond;

    private void Start()
    {
        scoreCount = 0f;
        pointsPerSecond = 1f;
    }

    private void Update()
    {
        scoreText.text = "Score: " +(int)scoreCount;
        scoreCount += pointsPerSecond * Time.deltaTime;
    }
}
