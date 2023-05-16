using System;

public class Score
{
    private int _score;

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
        Value++;
    }

    public void Reload()
    {
        Value = 0;
    }
}