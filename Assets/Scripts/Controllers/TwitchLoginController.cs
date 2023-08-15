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

    public void LoginIntoChat()
    {
        playButton.interactable = false;
        TwitchController.Login(twitchUserInput.text, twitchSettings);
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
        // TODO: Disable loading canvas
    }
}
