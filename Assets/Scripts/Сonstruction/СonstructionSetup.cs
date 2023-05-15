 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class СonstructionSetup : PresenterSetuper
{
    [SerializeField] private СonstructionView _view;

    private СonstructionModel _model;

    public СonstructionModel Model => _model;

    private void Awake()
    {
        _model = new СonstructionModel(_view.CenterOfMass);
        Presenter = new СonstructionPresenter(_view, _model);
    }
}
