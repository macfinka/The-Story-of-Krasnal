using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Mana : MonoBehaviour
{
    [SerializeField] int maxMana = 100;
    [SerializeField] private UnityEvent<int> OnManaChanged;
    [SerializeField] private UnityEvent<int> OnMaxManaSet;

    private int _currentMana;

    private void Awake()
    {
        _currentMana = maxMana;
    }

    private void Start()
    {
        OnMaxManaSet.Invoke(maxMana);
    }

    public void TakeMana(int manaTaken)
    {
        if (_currentMana <= 0)
        {
            return;
        }
        if (_currentMana-manaTaken>=0)
        {
            _currentMana -= manaTaken;
        }
        else
        {
            _currentMana = 0;
        }
        OnManaChanged.Invoke(_currentMana);
    }

    public void AddMana(int addAmount)
    {
        if (_currentMana + addAmount <= maxMana)
        {
            _currentMana += addAmount;

        }
        else
        {
            _currentMana = maxMana;
        }
        OnManaChanged.Invoke(_currentMana);
    }
}

