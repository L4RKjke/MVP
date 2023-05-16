using System;
using UnityEngine;

public class ConstructionView : MonoBehaviour
{
    [SerializeField] private Rigidbody _riggidbody;

    private bool _isTriggered = false;
    private Vector3 _centerOfMass;

    public event Action Triggered;
    public event Action CenterOfMassUpdated;

    public Vector3 Velocity { get; private set; }

    public Vector3 CenterOfMass => _centerOfMass;

    private void Update()
    {
        _centerOfMass = _riggidbody.worldCenterOfMass;
        CenterOfMassUpdated?.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out ConstructionView magnitableObject))
        {
            if (_isTriggered) return;

            _isTriggered = true;

            Velocity = (collision.contacts[0].normal * _riggidbody.mass);
            Triggered?.Invoke();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out ConstructionView magnitableObject))
        {
            _isTriggered = false;
        }
    }

    public void ChangeVelocity(Vector3 velocity)
    {
        _riggidbody.velocity = velocity;
    }

    public void AddForce(Vector3 direction)
    {
        _riggidbody.AddForce(direction);
    }
}