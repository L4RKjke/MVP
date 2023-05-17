using UnityEngine;

public class TimerSetup : Composite
{
    [SerializeField] private TimerUI _view;

    private Timer _model;

    public override void Compose()
    {
        _model = new Timer();
        Init(new TimerPresenter(_view, _model));
    }
}