using UnityEngine;
using System.Collections.Generic;

public class MagnetModel
{
    private readonly float  _magnetForce;
    private readonly List<IMagnitable> _targets = new List<IMagnitable>();

    private const float _minDistance = 1;

    public MagnetModel(float force)
    {
        _magnetForce = force;
    }

    public void AddTarget(IMagnitable target)
    {
        _targets.Add(target);
    }

    public void Magnetize(Transform transform)
    {
        for (int i = 0; i < _targets.Count; i++)
        {
            var direction = transform.position - _targets[i].CenterOfMass;
            float distance = direction.magnitude;
            var force = direction.normalized * _magnetForce * distance;

            if (distance > _minDistance)
            {
                _targets[i].Move(force);
            }
            else
            {
                if (_targets[i].IsMagnitable)
                    return;

                _targets[i].Stop();
            }
        }
    }
}