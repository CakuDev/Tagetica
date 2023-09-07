using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TimerBehaviour : MonoBehaviour
{
    [field: SerializeField] public float TotalTime { get; private set; } = 120;
    [SerializeField] private UnityEvent<float> onTimerDecreasing;
    [SerializeField] private UnityEvent onEndTimer;

    private float timer;
    private bool isTimerActive;

    private void Update()
    {
        if (isTimerActive && timer > 0f)
        {
            timer -= Time.deltaTime;
            onTimerDecreasing?.Invoke(timer);
        }
        if (timer < 0f)
        {
            timer = 0f;
            onEndTimer?.Invoke();
        }
        
    }

    public void InitTimer()
    {
        isTimerActive = true;
        timer = TotalTime;
    }

    public void StopTimer()
    {
        isTimerActive = false;
    }

    public void ResumeTimer()
    {
        isTimerActive = true;
    }

    // value format: 5s
    public void ChangeTotalTime(string value)
    {
        TotalTime = int.Parse(value.Split("s")[0]);
    }

    // value format: 2:00
    public void ChangeTotalTimeFromMinuteFormat(string value)
    {
        string[] valueSplit = value.Split(":");
        TotalTime = int.Parse(valueSplit[1]) + int.Parse(valueSplit[0]) * 60;
    }
}
