using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MagnetSetup : PresenterSetuper
{
    [SerializeField] private MagnetView _view;
    [SerializeField] private List<ConstructionSetup> _costractions;

    private const string _waitTargetsRoutineName = "WaitForTargetsRoutine";

    private MagnetModel _model;

    private void Awake()
    {
        _model = new MagnetModel(_view.Force);
        Init(new MagnetePresenter(_view, _model));
        StartCoroutine(_waitTargetsRoutineName);
    }

    private IEnumerator WaitForTargetsRoutine()
    {
        var lastConstractionElement = _costractions.Count - 1;

        yield return new WaitUntil(() => _costractions[lastConstractionElement].IsInitialized);

        for (int i = 0; i < _costractions.Count; i++)
        {
            _model.AddTarget(_costractions[i].Model);
        }
    }
}