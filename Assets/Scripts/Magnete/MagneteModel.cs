using UnityEngine;

public class MagneteModel
{
    private readonly float  _magineForce;

    public MagneteModel(float force)
    {
        _magineForce = force;
    }

    public void MagneteObject(IMagnitable target, Transform transform)
    {
        var direction = transform.position - target.CenterOfMass;
        float distance = direction.magnitude;
        var force = direction.normalized * _magineForce * distance;

        if (distance > 1f)
        {
            target.Move(force);
        }
        else
        {
            target.Stop();
        }
    }
}
