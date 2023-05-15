using UnityEngine;

public class MagnetablePresenter : Presenter
{
    private readonly IMagnitable _model;
    private readonly ConstructionView _view;

    public MagnetablePresenter(ConstructionView view, IMagnitable model)
    {
        _view = view;
        _model = model;
    }

    public override void Enable()
    {
        _model.ForceChanged += OnMove;
        _model.SpeedChanged += OnSpeedChanged;
        _view.CenterOfMassUpdated += UpdateCenter;
    }

    public override void Disable()
    {
        _model.ForceChanged -= OnMove;
        _model.SpeedChanged -= OnSpeedChanged;
        _view.CenterOfMassUpdated -= UpdateCenter;
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