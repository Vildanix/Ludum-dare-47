using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerAction : MonoBehaviour
{
    [SerializeField]
    private float countdownTime = 3.0f;
    private float remainingTime = 0;
    public UnityEvent AfterTimerAction = new UnityEvent();

    public void StartTimer()
    {
        remainingTime = countdownTime;
    }

    public void StopTimer()
    {
        remainingTime = -1f;
    }

    // return range from 0 to 1 for remaining time from total
    public float GetTimerProgress()
    {
        return remainingTime / countdownTime;
    }

    private void Update()
    {
        if (remainingTime >= 0)
        {
            remainingTime -= Time.deltaTime;

            if (remainingTime <= 0)
            {
                AfterTimerAction?.Invoke();
            }
        }
    }
}
