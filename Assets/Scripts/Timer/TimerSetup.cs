using UnityEngine;

public class TimerSetup : PresenterSetuper
{
    [SerializeField] private TimerUI _view;

    private Timer _model;

    public override void Composete()
    {
        _model = new Timer();
        Init(new TimerPresenter(_view, _model));
    }
}