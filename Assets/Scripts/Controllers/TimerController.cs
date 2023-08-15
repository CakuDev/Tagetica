using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private TextMeshProUGUI timerText;
    public void UdpdateTimerText(float timer)
    {
        // Int value used to avoid 1:60 format
        int timerFormat = (int)timer;
        timerText.text = $"{timerFormat / 60}:{timerFormat % 60:00}";
    }

    public void EndGame()
    {
        gameController.ChangeGameStatus(GameStatus.END_GAME);
    }
}
