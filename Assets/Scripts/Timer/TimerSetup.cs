using UnityEngine;

public class TimerSetup : Composite
{
    [SerializeField] private TimerUI _view;
    [SerializeField] private CoroutineRunner _runner;

    private Timer _model;

    public override void Compose()
    {
        _model = new Timer(_runner);
        Init(new TimerPresenter(_view, _model));
    }
}