using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameController gameController;

    public void StartGame()
    {
        // TODO: Change to starting when the counter is added
        gameController.ChangeGameStatus(GameStatus.START_PLAYING);
    }
}
