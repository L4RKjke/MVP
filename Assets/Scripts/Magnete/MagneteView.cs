using System;
using UnityEngine;

public class MagneteView : MonoBehaviour
{
    [SerializeField] private float _force;

    public event Action Updated;

    public Transform Transform => transform;

    public float Force => _force;

    private void FixedUpdate()
    {
        Updated?.Invoke();
    }
}