using AttackSystem;
using HealthSystem;
using UnityEngine;

namespace Projectile
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private float _damage;
        private ITarget _available;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Init(Vector3 velocity, float damage, ITarget available)
        {
            _rigidbody.velocity = velocity;
            _damage = damage;
            _available = available;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<Bullet>() != null)
            {
                return;
            }
            
            if (other.TryGetComponent(out IHealth health) && other.GetComponent<ITarget>().Equals(_available))
            {
                health.TakeDamage(_damage);
            }
            
            Destroy(gameObject);
        }
    }
}