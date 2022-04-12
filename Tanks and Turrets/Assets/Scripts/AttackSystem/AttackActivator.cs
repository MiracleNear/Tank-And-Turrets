using System;
using UnityEngine;

namespace AttackSystem
{
    [RequireComponent(typeof(Attack))]
    public class AttackActivator : MonoBehaviour
    {
        public event Action<ITarget> Found;
        public event Action Hided;
  
        public bool IsActivate => _isActivate;

        [SerializeField] private LayerMask _target;
        [SerializeField] private float _radius;

        private bool _isActivate;

        private void FixedUpdate()
        {
            Collider[] targets = Physics.OverlapSphere(transform.position, _radius, _target);

            if (targets.Length > 0)
            {
                if (targets[0].TryGetComponent(out ITarget target) && _isActivate == false)
                {
                    Found?.Invoke(target);
                    _isActivate = true;
                }
            }
            else
            {
                if (_isActivate == true)
                {
                    _isActivate = false;
                    Hided?.Invoke();
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1f, 0f, 0f, 0.25f);
            Gizmos.DrawSphere(transform.position, _radius);
        }
    }
}