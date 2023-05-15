using System.Collections;
using UnityEngine;
using System;

public class Timer
{
    private int _currentTime;

    public Action TimeUpdated;

    public int CurrentSeconds 
    {
        get => _currentTime;

        private set 
        {
            _currentTime = value;
            TimeUpdated?.Invoke();
        } 
    }

    public void StartTimer()
    {
        CoroutineRunner.Instance.StartRoutine(StartTimerRoutine());
    }

    public void Restart()
    {
        CurrentSeconds = 0;

        CoroutineRunner.Instance.StopCoroutine(StartTimerRoutine());
    }

    private IEnumerator StartTimerRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            CurrentSeconds++;
        }
    }
}