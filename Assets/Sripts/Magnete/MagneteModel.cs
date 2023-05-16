using UnityEngine;
using System.Collections.Generic;

public class MagneteModel
{
    private readonly float  _magineForce;
    private readonly List<IMagnitable> _targets = new List<IMagnitable>();

    public MagneteModel(float force)
    {
        _magineForce = force;
    }

    public void Init(IMagnitable target)
    {
        _targets.Add(target);
    }

    public void MagneteObject(Transform transform)
    {
        for (int i = 0; i < _targets.Count; i++)
        {
            var direction = transform.position - _targets[i].CenterOfMass;
            float distance = direction.magnitude;
            var force = direction.normalized * _magineForce * distance;

            if (distance > 1f)
            {
                _targets[i].Move(force);
            }
            else
            {
                _targets[i].Stop();
            }
        }
    }
}
