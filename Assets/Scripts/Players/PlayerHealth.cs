using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    private int _health = 100;
    public void ChangeHealth(int value)
    {
        _health += value;
        Debug.Log("health :" + value);
    }

    public int GetHealth()
    {
        Debug.Log("Get health :" + _health);
        return _health;

    }
}
