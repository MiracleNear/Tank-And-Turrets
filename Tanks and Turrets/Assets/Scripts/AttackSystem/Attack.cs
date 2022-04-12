using UnityEngine;

namespace AttackSystem
{
    [RequireComponent(typeof(AttackActivator), typeof(Tower), typeof(IReload))]
    public class Attack : MonoBehaviour
    {
        private ITarget _target;
        private IReload _reload;
        private AttackActivator _activator;
        private Tower _tower;
        private bool _isVisibleTarget;

        private void Awake()
        {
            _activator = GetComponent<AttackActivator>();
            _tower = GetComponent<Tower>();
            _reload = GetComponent<IReload>();
        }

        private void OnEnable()
        {
            _activator.Found += OnFound;
            _activator.Hided += OnHided;
        }

        private void OnDisable()
        {
            _activator.Found -= OnFound;
        }

        private void Update()
        {
            if (_activator.IsActivate)
            {
                _isVisibleTarget = CheckTargetVisibility();

                if (_isVisibleTarget)
                {
                    _tower.LookAt(_target);
                }
                else
                {
                    _tower.SetDefaultRotation();
                }
            }
        }

        public bool TryAttack()
        {
            if (_activator.IsActivate == false)
            {
                return false;
            }

            if (_isVisibleTarget == false)
            {
                return false;
            }

            if (_reload.IsReload == true)
            {
                return false;
            }
            
            
            return true;
        }

        public void Shoot()
        {
            _reload.StartReload();
            
            _tower.LaunchTo(_target);
        }

        private void OnHided()
        {
            _target = null;
            
            _tower.SetDefaultRotation();
        }

        private void OnFound(ITarget target)
        {
            _target = target;
        }

        private bool CheckTargetVisibility()
        {
            RaycastHit hitInfo = new RaycastHit();

            Vector3? direction = _target.Position - transform.position;

            if (direction.HasValue)
            {
                if (Physics.Raycast(transform.position, direction.Value, out hitInfo))
                {
                    if (hitInfo.collider.TryGetComponent(out Shelter shelter))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        
    }
}