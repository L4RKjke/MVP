using System;
using UnityEngine;

public class MagneteView : MonoBehaviour
{
    [SerializeField] private float _force;

    public Action<IMagnitable> Triggered;

    public Transform Transform => transform;

    public Vector3 Direction { get; private set; }

    public float Force => _force;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out ConstructionSetup setup))
        {
            Triggered?.Invoke(setup.Model);
        }
    }
}