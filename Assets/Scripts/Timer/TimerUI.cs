using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _time;
    [SerializeField] private Button _reloadButton;

    public event Action Cicked;
    public event Action GameStarted;

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
        _reloadButton.onClick.AddListener(OnResetButtonClick);
    }

    private void OnDisable()
    {
        _reloadButton.onClick.RemoveListener(OnResetButtonClick);
    }

    private void OnResetButtonClick()
    {
        Cicked?.Invoke();
    }
}