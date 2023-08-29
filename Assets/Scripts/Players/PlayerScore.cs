using UnityEngine;

public class PlayerScore : MonoBehaviour, IScore
{
    private int _score = 0;
    public void SetScore(int value)
    {
        _score += value;
        Debug.Log("Score: " + _score);
    }
    public int GetScore()
    {
        return _score;
    }
}
