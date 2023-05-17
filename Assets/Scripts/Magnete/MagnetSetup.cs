using UnityEngine;
using System.Collections.Generic;

public class MagnetSetup : Composite
{
    [SerializeField] private MagnetView _view;
    [SerializeField] private List<ConstructionSetup> _costractions;

    private List<IMagnitable> _targets = new List<IMagnitable>();

    private const string _waitTargetsRoutineName = "WaitForTargetsRoutine";

    private MagnetModel _model;

    public override void Compose()
    {
        SetTargets();
        _model = new MagnetModel(_view.Force, _targets);
        Init(new MagnetePresenter(_view, _model));
    }

    public void SetTargets()
    {
        for (int i = 0; i < _costractions.Count; i++)
        {
            _targets.Add(_costractions[i].Model);
        }
    }
}