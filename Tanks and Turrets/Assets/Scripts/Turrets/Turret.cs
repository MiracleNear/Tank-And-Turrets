using AttackSystem;
using HealthSystem;
using UnityEngine;

namespace Turrets
{
    [RequireComponent(typeof(Rigidbody), typeof(Attack))]
    public class Turret : MonoBehaviour, ITarget
    {
        private Rigidbody _rigidbody;
        private Attack _attack;
        private IHealth _health;
        private IVisitor _visitor;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _attack = GetComponent<Attack>();
            _health = GetComponent<IHealth>();
            _visitor = FindObjectOfType<DeathHandler>().GetComponent<IVisitor>();
        }


        private void OnEnable()
        {
            _health.Died += OnDied;
        }

        private void OnDisable()
        {
            _health.Died -= OnDied;
        }

        private void FixedUpdate()
        {
            if (_attack.TryAttack())
            {
                _attack.Shoot();
                
            }
        }

        private void OnDied()
        {
            _visitor.Visit(this);
        }

        public Vector3? Position
        {
            get
            {
                if (_rigidbody != null)
                {
                   return _rigidbody.position;
                }

                return null;
            }
        }
    }
}