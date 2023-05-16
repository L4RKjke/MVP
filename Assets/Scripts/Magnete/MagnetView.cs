using System;
using UnityEngine;

public class MagnetView : MonoBehaviour
{
    [SerializeField] private float _force;

    public event Action Updated;

    public float Force => _force;

    private void FixedUpdate()
    {
        Updated?.Invoke();
    }
}