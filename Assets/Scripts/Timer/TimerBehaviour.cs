using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TimerBehaviour : MonoBehaviour
{
    [field: SerializeField] public int TotalTime { get; private set; } = 120;
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
}
