using UnityEngine;

public class MagneteSetup : PresenterSetuper
{
    [SerializeField] private MagneteView _view;

    private MagneteModel _model;

    public MagneteModel Model => _model;

    private void Awake()
    {
        _model = new MagneteModel(_view.Force);
        Presenter = new MagnetePresenter(_view, _model);
    }
}