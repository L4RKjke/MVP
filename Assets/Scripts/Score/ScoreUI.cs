using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private ConstructionView _magnetic;
    [SerializeField] private Button _reloadButton;

    public event Action ScoreUpdated;
    public event Action Clicked;

    private void OnEnable()
    {
        _magnetic.Triggered += OnScoreChanged;
        _reloadButton.onClick.AddListener(OnRestrartButtonClick);
    }

    private void OnDisable()
    {
        _magnetic.Triggered -= OnScoreChanged;
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