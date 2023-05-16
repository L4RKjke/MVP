using System;
using UnityEngine;

public interface IMagnitable
{
    event Action<Vector3> ForceChanged;
    event Action SpeedChanged;

    bool IsMagnitable { get; }

    Vector3 CenterOfMass { get; }

    Vector3 Speed { get; }

    void Move(Vector3 direction);

    void Stop();

    void SetCenterOfMass(Vector3 centerOfMass);
}