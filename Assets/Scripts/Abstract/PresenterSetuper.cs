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
        GoThroughList(true);
    }

    private void OnDisable()
    {
        GoThroughList(false);
    }

    private void GoThroughList(bool isEnabled)
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