using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private TextMeshProUGUI timerText;

    public void UpdateTimerText(float timer)
    {
        // Int value used to avoid 1:60 format
        // 0.99 added to end exactly at 0
        int timerFormat = (int) timer;
        timerText.text = $"{timerFormat / 60}:{timerFormat % 60:00}";
    }

    public void EndGame()
    {
        gameController.ChangeGameStatus(GameStatus.END_GAME);
    }
}
