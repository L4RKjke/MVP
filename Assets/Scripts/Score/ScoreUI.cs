using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private ÑonstructionView _magnitable;
    [SerializeField] private Button _reloadButton;

    public Action ScoreUpdated;
    public Action Clicked;

    private void OnEnable()
    {
        _magnitable.Triggered += OnScoreChanged;
        _reloadButton.onClick.AddListener(OnRestrartButtonClick);
    }

    private void OnDisable()
    {
        _magnitable.Triggered -= OnScoreChanged;
        _reloadButton.onClick.RemoveListener(OnRestrartButtonClick);
    }

    public void SetAmount(int score)
    {
        _score.text = $"{score}";
    }

    private void OnScoreChanged()
    {
        ScoreUpdated?.Invoke();
    }

    private void OnRestrartButtonClick()
    {
        Clicked?.Invoke();
    }
}
