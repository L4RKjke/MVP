using System.Collections.Generic;
using UnityEngine;
using System;

public class CompositeOrder : MonoBehaviour
{
    [Header("Order for setupers")]
    [SerializeField] private List<PresenterSetuper> _setupsOrder;

    private void OnValidate()
    {
        if(_setupsOrder.Count == 0)
            throw new Exception("ListNotFilledException");
    }

    private void Awake()
    {
        for (int i = 0; i < _setupsOrder.Count; i++)
        {
            _setupsOrder[i].Composete();
            _setupsOrder[i].enabled = true;
        }
    }
}
