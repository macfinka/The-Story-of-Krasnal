using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] private UnityEvent<int> OnHealthChanged;
    [SerializeField] private UnityEvent<int> OnMaxHealthSet;

    [SerializeField] UnityEvent OnDeath;
    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = maxHealth;
    }

    private void Start()
    {
        OnMaxHealthSet.Invoke(maxHealth);
    }

    public void TakeDamage(int damageTaken)
    {
        if (_currentHealth <= 0)
        {
            return;
        }
        if (_currentHealth-damageTaken>=0)
        {
            _currentHealth -= damageTaken;
        }
        else
        {
            _currentHealth = 0;
        }
        OnHealthChanged.Invoke(_currentHealth);
        if (_currentHealth <= 0)
        {
            OnDeath.Invoke();
        }
    }

    public void Heal(int healAmount)
    {
        if (_currentHealth <= 0)
        {
            return;
        }
        if (_currentHealth + healAmount <= maxHealth)
        {
            _currentHealth += healAmount;

        }
        else
        {
            _currentHealth = maxHealth;
        }
        OnHealthChanged.Invoke(_currentHealth);
    }
}
