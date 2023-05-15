using UnityEngine;

public abstract class PresenterSetuper: MonoBehaviour
{
    protected Presenter Presenter { get; set; }

    private void OnEnable()
    {
        Presenter.Enable();
    }

    private void OnDisable()
    {
        Presenter.Disable();
    }
}
