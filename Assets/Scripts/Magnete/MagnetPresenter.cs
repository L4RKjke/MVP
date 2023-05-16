public class MagnetePresenter : Presenter
{
    private readonly MagnetView _view;
    private readonly MagnetModel _model;

    public MagnetePresenter(MagnetView view, MagnetModel model)
    {
        _view = view;
        _model = model;
    }

    public override void Enable()
    {
        _view.Updated += OnTriggered;
    }

    public override void Disable()
    {
        _view.Updated -= OnTriggered;
    }

    private void OnTriggered()
    {
        _model.Magnetize(_view.transform);
    }
}