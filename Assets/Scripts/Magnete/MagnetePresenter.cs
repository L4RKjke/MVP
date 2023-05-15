public class MagnetePresenter : Presenter
{
    private readonly MagneteView _view;
    private readonly MagneteModel _model;

    public MagnetePresenter(MagneteView view, MagneteModel model)
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
        _model.MagneteObject(_view.Magitable, _view.transform);
    }
}