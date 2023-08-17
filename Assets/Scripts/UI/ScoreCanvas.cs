using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCanvas : MonoBehaviour
{
    [SerializeField] private TimerBehaviour scoreTimerBehaviour;
    [SerializeField] private GameController gameController;

    public void EndGame()
    {
        if(scoreTimerBehaviour.isActiveAndEnabled) scoreTimerBehaviour.InitTimer();
        gameController.ChangeGameStatus(GameStatus.END_GAME);
    }

    public void HideToGame()
    {
        
        gameController.ChangeGameStatus(GameStatus.STARTING);
    }
}
