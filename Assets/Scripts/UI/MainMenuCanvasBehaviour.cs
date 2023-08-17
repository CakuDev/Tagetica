using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCanvasBehaviour : MonoBehaviour
{
    [SerializeField] private GameController gameController;

    public void Starting()
    {
        gameController.ChangeGameStatus(GameStatus.STARTING);
    }
}
