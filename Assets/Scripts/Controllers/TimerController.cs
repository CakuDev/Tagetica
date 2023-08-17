using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private TimerBehaviour timerBehaviour;
    [SerializeField] private TextMeshProUGUI timerText;

    public void UpdateTimerText(float timer)
    {
        // Int value used to avoid 1:60 format
        int timerFormat = (int) timer;
        timerText.text = $"{timerFormat / 60}:{timerFormat % 60:00}";
    }

    public void EndGame()
    {
        gameController.ChangeGameStatus(GameStatus.ENDING_GAME);
    }

    public void ResetTimerText()
    {
        int timerFormat = timerBehaviour.TotalTime;
        timerText.text = $"{timerFormat / 60}:{timerFormat % 60:00}";
    }
}
