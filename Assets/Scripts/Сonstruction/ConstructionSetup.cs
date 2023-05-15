using UnityEngine;

public class ConstructionSetup : PresenterSetuper
{
    [SerializeField] private ConstructionView _view;
    [SerializeField] private MagneteSetup _manget;

    private ConstructionModel _model;

    public ConstructionModel Model => _model;

    private void Awake()
    {
        _model = new ConstructionModel(_view.CenterOfMass, _manget.Model);
        Presenter = new ConstructionPresenter(_view, _model);
    }
}
