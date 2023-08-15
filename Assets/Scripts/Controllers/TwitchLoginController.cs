using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwitchChat;

public class TwitchLoginController : MonoBehaviour
{
    [SerializeField] private string twitchUsername;
    [SerializeField] private TwitchSettings twitchSettings;
    [SerializeField] private GameController gameController;

    void Start()
    {
        LoginIntoChat();
    }

    public void LoginIntoChat()
    {
        TwitchController.Login(twitchUsername, twitchSettings);
        TwitchController.onChannelJoined += OnChannelJoined;
    }

    public void OnChannelJoined()
    {
        // Use delay to allow the TwitchController to finish connection
        Invoke(nameof(ChangeGameStatus), 3f);
    }

    private void ChangeGameStatus()
    {
        gameController.ChangeGameStatus(GameStatus.START_PLAYING);
    }
}
