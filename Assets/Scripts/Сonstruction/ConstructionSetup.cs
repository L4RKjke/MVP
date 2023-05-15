using UnityEngine;

public class ConstructionSetup : PresenterSetuper
{
    [SerializeField] private ConstructionView _view;

    private ConstructionModel _model;

    public ConstructionModel Model => _model;

    private void Awake()
    {
        _model = new ConstructionModel(_view.CenterOfMass);
        Presenter = new ConstructionPresenter(_view, _model);
    }
}
