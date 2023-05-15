using UnityEngine;

public class TimerSetup : PresenterSetuper
{
    [SerializeField] private TimerUI _view;

    private Timer _model;

    private void Awake()
    {
        _model = new Timer();
        Presenter = new TimerPresenter(_view, _model);
    }
}