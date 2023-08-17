using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutoReplayBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TimerBehaviour timerBehaviour;

    public void UpdateTimerText(float timer)
    {
        // Int value used to avoid decimals format
        // 0.99 added to end exactly at 0
        int timerFormat = (int) (timer + 0.99f);
        timerText.text = timerFormat.ToString();
    }

    public void ResetTimerText()
    {
        int timerFormat = timerBehaviour.TotalTime;
        timerText.text = timerFormat.ToString();
    }
}
