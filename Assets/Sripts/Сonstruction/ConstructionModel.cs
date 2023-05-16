using System.Collections;
using System;
using UnityEngine;

public class ConstructionModel: IBouncy, IMagnitable
{
    private readonly float _force = 20;

    private System.Random _random;
    private IEnumerator _routine;
    private bool _canMove = true;
    private Vector3 _speed;

    public event Action<Vector3> ForceChanged;
    public event Action SpeedChanged;

    private Vector3 _direction;

    public Vector3 CenterOfMass { get; private set; }

    public Vector3 Speed 
    {
        get => _speed;

        private set 
        {
            _speed = value;
            SpeedChanged?.Invoke();
        }
    }

    public ConstructionModel(Vector3 centorOfMass, MagneteModel magnitable)
    {
        CenterOfMass = centorOfMass;
        _random = new System.Random(GetHashCode());
        magnitable.Init(this);
    }

    public void SetCenterOfMass(Vector3 centerOfMass)
    {
        CenterOfMass = centerOfMass;
    }

    public void Stop()
    {
        Speed = Vector3.zero;
    }
    
    public void Move(Vector3 direction)
    {
        if (_canMove)
            ForceChanged?.Invoke(direction);
    }

    public void Bounce(Vector3 direction)
    {
        _direction = direction * _force;

        if (_routine != null)
            CoroutineRunner.Instance.StopCoroutine(_routine);

        _routine = PushRoutine();
        CoroutineRunner.Instance.StartRoutine(_routine);
    }

    private IEnumerator PushRoutine()
    {
        _canMove = false;
        var time = GetRandomTime();

        while (time > 0)
        {
            Speed = _direction * time;
            time -= Time.deltaTime;

            yield return new WaitForFixedUpdate();
        }

        _canMove = true;
        Speed = Vector3.zero;
    }

    private float GetRandomTime()
    {
        int maxTimeDelay = 1;
        int minTimeDelay = 3;
        int defaultTime = 1;

        return defaultTime + 1 /
            _random.Next(maxTimeDelay, minTimeDelay);
    }
}