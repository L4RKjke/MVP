public class ScorePresenter: Presenter
{
    private readonly ScoreUI _view;
    private readonly Score _model;

    public ScorePresenter(ScoreUI view, Score model)
    {
        _view = view;
        _model = model;
    }

    public override void Enable()
    {
        _model.ScoreUpdated += OnScoreChanged;
        _view.ScoreUpdated += State—hanged;
        _view.Clicked += OnResetButtonClicked;
    }

    public override void Disable()
    {
        _model.ScoreUpdated -= OnScoreChanged;
        _view.ScoreUpdated -= State—hanged;
        _view.Clicked -= OnResetButtonClicked;
    }

    private void OnScoreChanged()
    {
        _view.SetAmount(_model.Value);
    }

    private void State—hanged()
    {
        _model.AddPoint();
    }

    private void OnResetButtonClicked()
    {
        _model.Reset();
    }
}