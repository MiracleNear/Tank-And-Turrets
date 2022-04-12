using System;
using System.Collections;
using UnityEngine;

namespace AttackSystem
{
    public class Reload : MonoBehaviour, IReload
    {
        [SerializeField] private float _duration;
        
        private float _timePassed;
        private bool _isReload;

        public float CurrentTime
        {
            get => _timePassed;
        }

        public float MaxTime
        {
            get => _duration;
        }

        public bool IsReload
        {
            get => _isReload;

        }

        public event Action Started;
        
        public event Action Tick;

        public event Action Ended;
        
        
        public void StartReload()
        {
            Started?.Invoke();
            _isReload = true; 
            StartCoroutine(Reloading());
        }

       


        private IEnumerator Reloading()
        {
            float startTime = Time.time;

            _timePassed = 0;
            
            while (_timePassed <= _duration)
            {
                Tick?.Invoke();
                
                _timePassed = Time.time - startTime;

                yield return null;
            }

            _isReload = false;
            Ended?.Invoke();
        }
        
    }
}