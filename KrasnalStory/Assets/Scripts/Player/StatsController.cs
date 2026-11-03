
using UnityEngine;
public class StatsController : MonoBehaviour
{
    Health health;
    Mana mana;
    Sobriety sobriety;
    private void Awake()
    {
        health = GetComponent<Health>();
        mana = GetComponent<Mana>();
        sobriety = GetComponent<Sobriety>();
    }
    
    void HealthPlayer()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            int d = 20;
            health.TakeDamage(d);
            Debug.Log($"{d} health taken");
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            int d = 20;
            health.Heal(d);
            Debug.Log($"{d} health healed");
        }
    }
    void ManaPlayer()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            int d = 20;
            mana.TakeMana(d);
            Debug.Log($"{d} mana taken");
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            int d = 20;
            mana.AddMana(d);
            Debug.Log($"{d} mana healed");
        }
    }
    void SobrietyPlayer()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            int d = 20;
            sobriety.TakeSobriety(d);
            Debug.Log($"{d} sobriety taken");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            int d = 20;
            sobriety.AddSobriety(d);
            Debug.Log($"{d} sobriety healed");
        }
    }
    private void Update()
    {
        HealthPlayer();
        ManaPlayer();
        SobrietyPlayer();
    }
}
