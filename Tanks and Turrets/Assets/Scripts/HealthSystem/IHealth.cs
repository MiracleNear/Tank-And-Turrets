using System;

namespace HealthSystem
{
    public interface IHealth
    {
        public float CurrentHealth { get; }
        public float MaxHealth { get; }

        public event Action Changed;
        public event Action Filled;
        public event Action Died;
        public void TakeDamage(float damage);

        public void Add(float health);

    }
}