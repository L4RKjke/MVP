using UnityEngine;

public class ConstructionSetup : PresenterSetuper
{
    [SerializeField] private ConstructionView _view;

    public ConstructionModel Model { get; private set; }

    public bool IsInitialized { get; private set; } = false;

    private void Awake()
    {
        Model = new ConstructionModel(_view.CentorOfMass);
        Init(new MagnetablePresenter(_view, Model));
        Init(new BouncePresenter(_view, Model));

        IsInitialized = true;
    }
}