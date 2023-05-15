using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _time;
    [SerializeField] private Button _reloadButton;

    public Action Cicked;
    public Action GameStarted;

    public void SetAmount(int time)
    {
        _time.text = $"{time}";
    }

    private void Start()
    {
        GameStarted?.Invoke();
    }

    private void OnEnable()
    {
        _reloadButton.onClick.AddListener(OnRestrartButtonClick);
    }

    private void OnDisable()
    {
        _reloadButton.onClick.RemoveListener(OnRestrartButtonClick);
    }

    private void OnRestrartButtonClick()
    {
        Cicked?.Invoke();
    }
}