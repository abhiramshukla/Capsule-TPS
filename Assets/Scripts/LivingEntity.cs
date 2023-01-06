using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable
{
    [SerializeField] protected float _health;
    protected bool _dead;
    public event System.Action OnDeath;

    public void TakeDamage(float damage, RaycastHit raycastHit)
    {
        _health -= damage;

        if (_health <= 0 && !_dead) 
            Die();
    }

    private void Die()
    {
        _dead = true;
        if(OnDeath != null)
            OnDeath();
        GameObject.Destroy(gameObject);
    }
}
