using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [field: SerializeField] UnityEvent onStarting;
    [field: SerializeField] UnityEvent onStartPlaying;
    [field: SerializeField] UnityEvent onResumePlaying;
    [field: SerializeField] UnityEvent onEndingGame;
    [field: SerializeField] UnityEvent onEndGame;

    private GameStatus gameStatus;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

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
            case GameStatus.ENDING_GAME:
                onEndingGame?.Invoke();
                break;
            case GameStatus.END_GAME:
                onEndGame?.Invoke();
                break;
        }
    }
}
