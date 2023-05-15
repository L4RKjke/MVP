using System;
using UnityEngine;

public class MagneteView : MonoBehaviour
{
    [SerializeField] private float _force;

    public Transform Transform => transform;

    public Action Triggered;

    public Vector3 Direction { get; private set; }

    public float Force => _force;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out ConstructionView view))
        {
            Triggered?.Invoke();
        }
    }
}