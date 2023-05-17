using System.Collections;
using UnityEngine;
using System;

public class Timer
{
    private int _currentTime;
    private IEnumerator _timeRoutine;

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
        if (_timeRoutine == null) return;

        CoroutineRunner.Instance.StopRoutine(_timeRoutine);
        StartTimer();
    }

    public void StartTimer()
    {
        _timeRoutine = StartTimerRoutine();
        CoroutineRunner.Instance.StartRoutine(_timeRoutine);
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