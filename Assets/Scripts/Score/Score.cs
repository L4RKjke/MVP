using System;

public class Score
{
    private int _score;

    private const int _maxScore = int.MaxValue;

    public event Action ScoreUpdated;

    public int Value 
    {
        get => _score;

        private set
        {
            _score = value;
            ScoreUpdated?.Invoke();
        }
    }

    public void AddPoint()
    {
        if (Value == _maxScore)
            Value--;

        Value++;
    }

    public void Reset()
    {
        Value = 0;
    }
}