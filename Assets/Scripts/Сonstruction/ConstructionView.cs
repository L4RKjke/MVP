using System;
using UnityEngine;
using System.Collections;

public class ConstructionView : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private bool _isTriggered = false;
    private Vector3 _centerOfMass;

    public event Action Triggered;
    public event Action CenterOfMassUpdated;

    public Vector3 Velocity { get; private set; }

    public Vector3 CentorOfMass => _centerOfMass;

    private void Update()
    {
        _centerOfMass = _rigidbody.worldCenterOfMass;
        CenterOfMassUpdated?.Invoke();
    }

    #region UnityTriggers
    private void OnCollisionEnter(Collision collision)
    {
        if (_isTriggered)
            return;

        if (collision.gameObject.TryGetComponent(out ConstructionView magnitableObject))
        {
            _isTriggered = true;

            Velocity = (collision.contacts[0].normal * _rigidbody.mass);
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
    #endregion

    public void ChangeVelocity(Vector3 velocity)
    {
        _rigidbody.velocity = velocity;
    }

    public void AddForce(Vector3 direction)
    {
        _rigidbody.AddForce(direction);
    }
}