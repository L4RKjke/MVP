using UnityEngine;

public class ConstructionSetup : Composite
{
    [SerializeField] private ConstructionView _view;
    [SerializeField] private CoroutineRunner _runner;

    public ConstructionModel Model { get; private set; }

    public override void Compose()
    {
        Model = new ConstructionModel(_view.CentorOfMass, _runner);
        Init(new MagnetablePresenter(_view, Model));
        Init(new BouncePresenter(_view, Model));
    }
}