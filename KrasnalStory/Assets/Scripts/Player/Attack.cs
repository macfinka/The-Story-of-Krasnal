using UnityEngine;
using UnityEngine.Events;

public class Attack : MonoBehaviour
{
    [SerializeField] int maxAttackDamage = 100;
    [SerializeField] private UnityEvent<int> OnAttacking;

    private int _attackDamage;

    public Collider2D attacktriger;
    private float _attackTime;
    private float _attackCd = 0.3f;
    private bool _isAttacking;

    void Awake()
    {
        _attackDamage = maxAttackDamage;
        attacktriger.enabled = false;
    }

    public void PlayerAttack()
    {
        if (!_isAttacking)
        {
            _isAttacking = true;
            attacktriger.enabled = true;
            _attackTime = _attackCd;
            if (attacktriger.TryGetComponent(out Enemy enemy)) // did it collide with an enemy
                enemy.TakeDamage(_attackDamage);
        }
        if (_isAttacking && _attackTime > 0)
        {             
            _attackTime -= Time.fixedDeltaTime;
        }
        _isAttacking = false;
        attacktriger.enabled = false;

        OnAttacking.Invoke(_attackDamage);
    }
}
