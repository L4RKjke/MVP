using UnityEngine;

public class TimerSetup : PresenterSetuper
{
    [SerializeField] private TimerUI _view;

    private Timer _model;

    private void Awake()
    {
        _model = new Timer();
        Init(new TimerPresenter(_view, _model));
    }
}