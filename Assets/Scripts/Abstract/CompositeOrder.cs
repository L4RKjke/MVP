using System.Collections.Generic;
using UnityEngine;
using System;

public class CompositeOrder : MonoBehaviour
{
    [Header("Order for setupers")]
    [SerializeField] private List<Composite> _setupsOrder;

    private const string _errorName = "ListNotFilledException";

    private void OnValidate()
    {
        if (_setupsOrder.Count == 0)
            throw new Exception(_errorName);
    }

    private void Awake()
    {
        for (int i = 0; i < _setupsOrder.Count; i++)
        {
            _setupsOrder[i].Compose();
            _setupsOrder[i].enabled = true;
        }
    }
}