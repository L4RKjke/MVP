using System;

public class Score
{
    private int _score;

    public int Value 
    {
        get => _score;

        private set
        {
            _score = value;
            ScoreUpdated?.Invoke();
        }
    }

    public Action ScoreUpdated; 

    public void AddPoint()
    {
        Value++;
    }

    public void Reload()
    {
        Value = 0;
    }
}