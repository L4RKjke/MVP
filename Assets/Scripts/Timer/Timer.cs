using System.Collections;
using UnityEngine;
using System;

public class Timer
{
    private int _currentTime;
    private IEnumerator _timeRoutine;
    private IRounineRunner _rounineRunner;

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

    public Timer(IRounineRunner service)
    {
        _rounineRunner = service;
    }

    public void Reset()
    {
        if (_timeRoutine == null) return;

        _rounineRunner.StopRoutine(_timeRoutine);
        StartTimer();
    }

    public void StartTimer()
    {
        _timeRoutine = StartTimerRoutine();
        _rounineRunner.StartRoutine(_timeRoutine);
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