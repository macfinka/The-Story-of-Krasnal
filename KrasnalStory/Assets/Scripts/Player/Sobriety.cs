using UnityEngine;
using UnityEngine.Events;

public class Sobriety : MonoBehaviour
{
    [SerializeField] int maxSobriety = 100;
    [SerializeField] private UnityEvent<int> OnSobrietyChanged;
    [SerializeField] private UnityEvent<int> OnMaxSobrietySet;

    private int _currentSobriety;

    private void Awake()
    {
        _currentSobriety = maxSobriety;
    }

    private void Start()
    {
        OnMaxSobrietySet.Invoke(maxSobriety);
    }

    public void TakeSobriety(int sobrietyTaken)
    {
        if (_currentSobriety <= 0)
        {
            return;
        }
        if (_currentSobriety-sobrietyTaken>=0)
        {
            _currentSobriety -= sobrietyTaken;
        }
        else
        {
            _currentSobriety = 0;
        }
        OnSobrietyChanged.Invoke(_currentSobriety);
    }

    public void AddSobriety(int addAmount)
    {
        if (_currentSobriety + addAmount <= maxSobriety)
        {
            _currentSobriety += addAmount;

        }
        else
        {
            _currentSobriety = maxSobriety;
        }
        OnSobrietyChanged.Invoke(_currentSobriety);
    }
}