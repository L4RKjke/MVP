public class BouncePresenter : Presenter
{
    private readonly IBouncy _model;
    private readonly ConstructionView _view;

    public BouncePresenter(ConstructionView view, IBouncy model)
    {
        _view = view;
        _model = model;
    }

    public override void Enable()
    {
        _view.Triggered += OnTriggered;
    }

    public override void Disable()
    {
        _view.Triggered -= OnTriggered;
    }

    private void OnTriggered()
    {
        _model.Bounce(_view.Velocity);
    }
}