using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private int Score = 0;

    public void UpdateScore(int points)
    {
        Score += points;
        scoreText.text = Score.ToString();
    }
}
