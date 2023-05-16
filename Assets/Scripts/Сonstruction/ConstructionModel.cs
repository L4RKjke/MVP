using System.Collections;
using System;
using UnityEngine;

public class ConstructionModel: IBouncy, IMagnitable
{
    private IEnumerator _pushRoutine;
    private bool _canMove = true;
    private Vector3 _speed;

    private readonly float _force = 22;
    private readonly System.Random _random;

    #region Constants
    private const int _maxTimeDelay = 1;
    private const int _minTimeDelay = 3;
    private const int _defaultTime = 1;
    #endregion

    #region Events
    public event Action<Vector3> ForceChanged;
    public event Action SpeedChanged;
    #endregion

    #region Properties
    public bool IsMagnitable { get; private set; } = false;

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
    #endregion

    public ConstructionModel(Vector3 centorOfMass)
    {
        CenterOfMass = centorOfMass;
        _random = new System.Random(GetHashCode());
    }

    # region Methods
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

        if (_pushRoutine != null)
            CoroutineRunner.Instance.StopRoutine(_pushRoutine);

        _pushRoutine = PushRoutine();
        CoroutineRunner.Instance.StartRoutine(_pushRoutine);
    }

    private IEnumerator PushRoutine()
    {
        IsMagnitable = true;
        _canMove = false;
        var time = GetRandomTime();

        while (time > 0)
        {
            Speed = _direction * time;
            time -= Time.deltaTime;

            yield return new WaitForFixedUpdate();
        }

        IsMagnitable = false;
        _canMove = true;
        Speed = Vector3.zero;
    }

    private float GetRandomTime()
    {
        return _defaultTime + 1 /
            _random.Next(_maxTimeDelay, _minTimeDelay);
    }
    #endregion
}