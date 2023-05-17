using System;
using UnityEngine;

public class MagnetView : MonoBehaviour
{
    [Header("Magnet force")]
    [SerializeField] private float _force;

    public event Action Updated;

    public float Force => _force;

    private void FixedUpdate()
    {
        Updated?.Invoke();
    }
}