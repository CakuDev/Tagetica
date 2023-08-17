using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvasBehaviour : MonoBehaviour
{
    [SerializeField] private GameController gameController;

    public void StartGame()
    {
        gameController.ChangeGameStatus(GameStatus.START_PLAYING);
    }

    public void EndGame()
    {
        gameController.ChangeGameStatus(GameStatus.END_GAME);
    }
}
