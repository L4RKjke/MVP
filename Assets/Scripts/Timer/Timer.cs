using System.Collections;
using UnityEngine;
using System;
///test
public class Timer
{
    private int _currentTime;

    public event Action TimeUpdated;

    private IEnumerator _routine;

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
        _routine = StartTimerRoutine();
        CoroutineRunner.Instance.StartRoutine(_routine);
    }

    public void Restart()
    {
        if (_routine == null) return;

        CoroutineRunner.Instance.StopCoroutine(_routine);
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
