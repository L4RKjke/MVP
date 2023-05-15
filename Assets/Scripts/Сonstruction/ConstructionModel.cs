using System.Collections;
using System;
using UnityEngine;

public class ConstructionModel: IBouncy, IMagnitable
{
    [SerializeField] private float _pushForce;

    private System.Random _random;
    private IEnumerator _routine;
    private bool _canMove = true;

    public Action<Vector3> ForceChanged;
    public Action SpeedChanged;

    public Vector3 Speed { get; private set; }

    public Vector3 Force { get; private set; } 

    public Vector3 CenterOfMass { get; private set; }

    private Vector3 _direction;

    public ConstructionModel(Vector3 centorOfMass) 
    {
        CenterOfMass = centorOfMass;
        _random = new System.Random(GetHashCode());
    }

    public void SetCenterOfMass(Vector3 centerOfMass)
    {
        CenterOfMass = centerOfMass;
    }

    public void Stop()
    {
        Speed = Vector3.zero;
        SpeedChanged?.Invoke();
    }
    
    public void Move(Vector3 direction)
    {
        if (_canMove)
            ForceChanged?.Invoke(direction);
    }

    public void Bounce(Vector3 direction)
    {
        _direction = direction * 20;

        if (_routine != null)
            CoroutineRunner.Instance.StopCoroutine(_routine);

        _routine = PushRoutine();
        CoroutineRunner.Instance.StartRoutine(_routine);
    }

    private IEnumerator PushRoutine()
    {
        _canMove = false;
        int maxTimeDelay = 1;
        int minTimeDelay = 3;
        int defaultTime = 1;

        float time = defaultTime + 1 /
            _random.Next(maxTimeDelay, minTimeDelay);

        while (time > 0)
        {
            yield return new WaitForFixedUpdate();

            Speed = _direction * time;
            SpeedChanged?.Invoke();
            time -= Time.deltaTime;
        }

        _canMove = true;
        Speed = Vector3.zero;
        SpeedChanged?.Invoke();
    }
}