using System;
using UnityEngine;

namespace HealthSystem
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField] private float _health;
        [SerializeField] private float _maxHealth;
        
        public event Action Changed;
        public event Action Filled;
        public event Action Died;

        public float CurrentHealth
        {
            get => _health;
        }

        public float MaxHealth
        {
            get => _maxHealth;

        }
        
        public void TakeDamage(float damage)
        {
            _health = Mathf.Clamp(_health - damage, 0, _maxHealth);
            
            Changed?.Invoke();
            
            if (_health <= 0)
            {
                Died?.Invoke();
            }
        }

        public void Add(float health)
        {
            _health = Mathf.Clamp(_health + health, 0, _maxHealth);
            
            Changed?.Invoke();

            if (_health.Equals(_maxHealth))
            {
                Filled?.Invoke();
            }
        }
    }
}