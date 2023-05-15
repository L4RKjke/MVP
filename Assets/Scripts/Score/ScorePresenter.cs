public class ScorePresenter: Presenter
{
    private ScoreUI _view;
    private Score _model;

    public ScorePresenter(ScoreUI view, Score model)
    {
        _view = view;
        _model = model;
    }

    public override void Enable()
    {
        _model.ScoreUpdated += OnScoreChanged;
        _view.ScoreUpdated += StateSchanged;
        _view.Clicked += OnReloadButtonClicked;
    }

    public override void Disable()
    {
        _model.ScoreUpdated -= OnScoreChanged;
        _view.ScoreUpdated -= StateSchanged;
        _view.Clicked -= OnReloadButtonClicked;
    }

    private void OnScoreChanged()
    {
        _view.SetAmount(_model.Value);
    }

    private void StateSchanged()
    {
        _model.AddPoint();
    }

    private void OnReloadButtonClicked()
    {
        _model.Reload();
    }
}
