using UnityEngine;

public class ScoreSetup : PresenterSetuper
{
    [SerializeField] private ScoreUI _view;

    private Score _model;

    private void Awake()
    {
        _model = new Score();
        Init(new ScorePresenter(_view, _model));
    }
}
