using UnityEngine;

public class ConstructionSetup : PresenterSetuper
{
    [SerializeField] private ConstructionView _view;

    public ConstructionModel Model { get; private set; }

    public override void Composete()
    {
        Model = new ConstructionModel(_view.CentorOfMass);
        Init(new MagnetablePresenter(_view, Model));
        Init(new BouncePresenter(_view, Model));
    }
}