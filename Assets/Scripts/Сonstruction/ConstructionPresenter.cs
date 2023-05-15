using UnityEngine;

public class ConstructionPresenter : Presenter
{
    private readonly ConstructionModel _model;
    private readonly ConstructionView _view;

    public ConstructionPresenter(ConstructionView view,  ConstructionModel model)
    {
        _view = view;
        _model = model;
    }

    public override void Enable()
    {
        _model.ForceChanged += OnMove;
        _model.SpeedChanged += OnSpeedChanged;
        _view.CenterOfMassUpdated += UpdateCenter;
        _view.Triggered += OnTriggered;
    }

    public override void Disable()
    {
        _model.ForceChanged -= OnMove;
        _model.SpeedChanged -= OnSpeedChanged;
        _view.CenterOfMassUpdated -= UpdateCenter;
        _view.Triggered -= OnTriggered;
    }

    private void OnTriggered()
    {
        _model.Bounce(_view.Velocity);
    }

    private void OnMove(Vector3 direction)
    {
        _view.AddForce(direction);
    }

    private void OnSpeedChanged()
    {
        _view.ChangeVelocity(_model.Speed);
    }

    private void UpdateCenter()
    {
        _model.SetCenterOfMass(_view.CenterOfMass);
    }
}