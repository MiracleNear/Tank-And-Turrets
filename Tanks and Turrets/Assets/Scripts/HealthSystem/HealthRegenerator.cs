using System.Collections;
using UnityEngine;

namespace HealthSystem
{
    public class HealthRegenerator : MonoBehaviour
    {
        [SerializeField] private float _watingTimeRecovery;
        [SerializeField] private float _timeBetweenRegeneration;
        [SerializeField] private float _quantity;

        private IHealth _health;
        private Coroutine _regeneration;
        
        private void OnValidate()
        {
            if (_watingTimeRecovery < 0)
            {
                _watingTimeRecovery = 0f;
            }

            if (_timeBetweenRegeneration < 0)
            {
                _timeBetweenRegeneration = 0f;
            }

            if (_quantity < 0)
            {
                _quantity = 0;
            }
        }

        private void Awake()
        {
            _health = GetComponent<IHealth>();

        }

        private void OnEnable()
        {
            _health.Changed += OnChanged;
            _health.Filled += OnFilled;
        }

        private void OnDisable()
        {
            _health.Changed -= OnChanged;
            _health.Changed -= OnFilled;
        }

        private void OnFilled()
        {
            StopCoroutine(_regeneration);
        }

        private void OnChanged()
        {
            if (_regeneration != null)
            {
                StopCoroutine(_regeneration);
            }

            _regeneration = StartCoroutine(Regeniration());
        }

        private IEnumerator Regeniration()
        {
            yield return new WaitForSeconds(_watingTimeRecovery);

            while (true)
            {
                _health.Add(_quantity);
                yield return new WaitForSeconds(_timeBetweenRegeneration);
            }
            
        }
    }
}