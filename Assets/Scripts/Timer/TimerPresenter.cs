public class TimerPresenter: Presenter
{
    private readonly TimerUI _view;
    private readonly Timer _model;

    public TimerPresenter(TimerUI view, Timer model)
    {
        _view = view;
        _model = model;
    }

    public override void Enable()
    {
        _model.TimeUpdated += OnTimeUpdated;
        _view.Cicked += OnReloadButtonClicked;
        _view.GameStarted += OnGameStarted;
    }

    public override void Disable()
    {
        _model.TimeUpdated -= OnTimeUpdated;
        _view.Cicked -= OnReloadButtonClicked;
        _view.GameStarted -= OnGameStarted;
    }

    private void OnTimeUpdated()
    {
        _view.SetAmount(_model.CurrentSeconds);
    }

    private void OnReloadButtonClicked()
    {
        _model.Reset();
    }

    private void OnGameStarted()
    {
        _model.StartTimer();
    }
}