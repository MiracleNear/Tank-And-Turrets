using Projectile;
using UnityEngine;

namespace AttackSystem
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private Transform _tower;
        [SerializeField] private Transform _placeLaunch;
        [SerializeField] private Bullet _template;
        [SerializeField] private float _speedLaunch;
        [SerializeField] private float _damage;
        
        public void LookAt(ITarget target)
        {
            Vector3? directionLook = target.Position - _tower.position;

            if (directionLook.HasValue)
            {
                Vector3 direction = directionLook.Value;

                direction.y = 0;
                
                Quaternion torque = Quaternion.LookRotation(direction, Vector3.up);

                _tower.rotation = torque;
            }
        }


        public void SetDefaultRotation()
        {
            _tower.rotation = Quaternion.identity;
        }

        public void LaunchTo(ITarget target)
        {
            Bullet bullet = Instantiate(_template, _placeLaunch.position, Quaternion.identity);

            Vector3? direction = (target.Position - _placeLaunch.position);

            if (direction.HasValue)
            {
                bullet.Init(direction.Value.normalized * _speedLaunch, _damage, target);
            }
            
        }
    }
}