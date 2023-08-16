using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI userAndChatText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject autoPlaySection;
    [SerializeField] private GameObject manualPlaySection;
    [SerializeField] private TwitchLoginController twitchLoginController;
    [SerializeField] private ScoreController scoreController;

    public void EndGame()
    {
        string username = twitchLoginController.Username;
        int score = scoreController.Score;
        userAndChatText.text = $"{username}'s chat achieved";
        scoreText.text = score.ToString();
    }

    public void SetAutoPlayEnabled(bool isAutoPlayEnabled)
    {
        autoPlaySection.SetActive(isAutoPlayEnabled);
        manualPlaySection.SetActive(!isAutoPlayEnabled);
    }
}
