using System;
using UnityEngine;

public interface IMagnitable
{
    public event Action<Vector3> ForceChanged;
    public event Action SpeedChanged;

    public Vector3 CenterOfMass { get; }

    public Vector3 Speed { get; }

    public Vector3 Force { get; }

    public void Move(Vector3 direction);

    public void Stop();

    public void SetCenterOfMass(Vector3 centerOfMass);
}