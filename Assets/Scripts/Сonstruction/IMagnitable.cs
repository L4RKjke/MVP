using System;
using UnityEngine;

public interface IMagnitable
{
    public Vector3 CenterOfMass { get; }

    public void Move(Vector3 direction);

    public void Stop( );
}