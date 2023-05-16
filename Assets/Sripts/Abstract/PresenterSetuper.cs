using UnityEngine;
using System.Collections.Generic;

public abstract class PresenterSetuper: MonoBehaviour
{
    private readonly List<Presenter> _presenters = new List<Presenter>();

    protected void Init(Presenter presenter)
    {
        _presenters.Add(presenter);
    }

    private void OnEnable()
    {
        for (int i = 0; i < _presenters.Count; i++)
        {
            _presenters[i].Enable();
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _presenters.Count; i++)
        {
            _presenters[i].Disable();
        }
    }
}