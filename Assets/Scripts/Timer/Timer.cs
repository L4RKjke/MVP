using System.Collections;
using UnityEngine;
using System;

public class Timer
{
    private int _currentTime;
    private IEnumerator _routine;

    public event Action TimeUpdated;

    public int CurrentSeconds 
    {
        get => _currentTime;

        private set 
        {
            _currentTime = value;

            if (_currentTime == int.MaxValue)
                Reset();

            TimeUpdated?.Invoke();
        } 
    }

    public void Reset()
    {
        if (_routine == null) return;

        CoroutineRunner.Instance.StopRoutine(_routine);
        StartTimer();
    }

    public void StartTimer()
    {
        _routine = StartTimerRoutine();
        CoroutineRunner.Instance.StartRoutine(_routine);
    }

    private IEnumerator StartTimerRoutine()
    {
        CurrentSeconds = 0;

        while (true)
        {
            yield return new WaitForSeconds(1);

            CurrentSeconds++;
        }
    }
}