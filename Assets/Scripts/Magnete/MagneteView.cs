using System;
using UnityEngine;

public class MagneteView : MonoBehaviour
{
    [SerializeField] private float _force;

    public Action Triggered;

    public Action<Vector3> Moved;

    public Action Stoped;

    public Transform Transform => transform;

    public IMagnitable Magitable { get; private set; }

    public Vector3 Direction { get; private set; }

    public float Force => _force;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out ÑonstructionSetup magitableObject))
        {
            Magitable = magitableObject.Model;
            Triggered?.Invoke();
        }
    }
}
