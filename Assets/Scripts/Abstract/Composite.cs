using UnityEngine;
using System.Collections.Generic;

public abstract class Composite: MonoBehaviour
{
    private readonly List<Presenter> _presenters = new List<Presenter>();

    private void OnEnable()
    {
        ChangePresentersState(true);
    }

    private void OnDisable()
    {
        ChangePresentersState(false);
    }

    protected void Init(Presenter presenter)
    {
        _presenters.Add(presenter);
    }

    abstract public void Compose();

    private void ChangePresentersState(bool isEnabled)
    {
        for (int i = 0; i < _presenters.Count; i++)
        {
            if (isEnabled)
                _presenters[i].Enable();
            else
                _presenters[i].Disable();     
        }
    }
}