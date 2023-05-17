using UnityEngine;

public class ScoreSetup : Composite
{
    [SerializeField] private ScoreUI _view;

    private Score _model;

    public override void Compose()
    {
        _model = new Score();
        Init(new ScorePresenter(_view, _model));
    }
}
