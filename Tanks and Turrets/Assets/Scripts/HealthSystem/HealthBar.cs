using UnityEngine;

namespace HealthSystem
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private HealthView _healthView;
        [SerializeField] private GameObject _healthContainer;
        
        private IHealth _health;
        private bool _isActive;

        private void OnValidate()
        {
            if (_healthContainer != null && _healthContainer.GetComponent<IHealth>() == null)
            {
                _health = null;
            }
        }

        private void Awake()
        {
            _health = _healthContainer.GetComponent<IHealth>();
        }

        private void OnEnable()
        {
            _health.Changed += OnChanged;
        }

        private void OnDisable()
        {
            _health.Changed -= OnChanged;
        }

        private void OnChanged()
        {
            float amount = _health.CurrentHealth / _health.MaxHealth;
            
            _healthView.UpdateBar(amount);
            
            if (amount < 1f && _isActive == false)
            {
                _isActive = true;
                _healthView.Show();
            }

            if (amount.Equals(1f) && _isActive == true)
            {
                _isActive = false;
                _healthView.Hide();
            }
        }
        
    }
}