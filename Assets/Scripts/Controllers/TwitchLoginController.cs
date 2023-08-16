using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwitchChat;
using TMPro;
using UnityEngine.UI;

public class TwitchLoginController : MonoBehaviour
{
    [SerializeField] private TMP_InputField twitchUserInput;
    [SerializeField] private TwitchSettings twitchSettings;
    [SerializeField] private Button playButton;
    [SerializeField] private Button connectButton;

    public string Username { get; private set; }

    public void LoginIntoChat()
    {
        playButton.interactable = false;
        connectButton.interactable = false;
        Username = twitchUserInput.text;
        TwitchController.Login(Username, twitchSettings);
        TwitchController.onChannelJoined += OnChannelJoined;
    }

    public void OnChannelJoined()
    {
        // Use delay to allow the TwitchController to finish connection
        Invoke(nameof(ChangeGameStatus), 3f);
    }

    private void ChangeGameStatus()
    {
        playButton.interactable = true;
        connectButton.interactable = true;
        // TODO: Disable loading canvas
    }

    private void OnDestroy()
    {
        TwitchController.onChannelJoined -= OnChannelJoined;
    }
}
