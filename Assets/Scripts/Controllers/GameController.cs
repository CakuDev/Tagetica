using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    private GameStatus gameStatus;
    [field: SerializeField] UnityEvent onStarting;
    [field: SerializeField] UnityEvent onStartPlaying;
    [field: SerializeField] UnityEvent onPaused;
    [field: SerializeField] UnityEvent onResumePlaying;
    [field: SerializeField] UnityEvent onEndGame;

    public void ChangeGameStatus(GameStatus newGameStatus)
    {
        gameStatus = newGameStatus;
        switch(gameStatus)
        {
            case GameStatus.STARTING:
                onStarting?.Invoke();
                break;
            case GameStatus.START_PLAYING:
                onStartPlaying?.Invoke();
                break;
            case GameStatus.PAUSED:
                onPaused?.Invoke();
                break;
            case GameStatus.RESUME_PLAYING:
                onResumePlaying?.Invoke();
                break;
            case GameStatus.END_GAME:
                onEndGame?.Invoke();
                break;
        }
    }
}
