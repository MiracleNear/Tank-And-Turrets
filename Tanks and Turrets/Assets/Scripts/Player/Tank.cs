using AttackSystem;
using HealthSystem;
using InputSystem;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody), typeof(Attack))]
    public class Tank : MonoBehaviour, ITarget
    {
        [SerializeField] private GameObject _keyboardInput;
        [SerializeField] private float _speedModulus;
        [SerializeField] private Transform _body;

        private IKeyboardInput _input;
        private Rigidbody _selfBody;
        private Attack _attack;
        private IHealth _health;
        private IVisitor _visitor;
        
        private void OnValidate()
        {
            if (_keyboardInput != null && _keyboardInput.GetComponent<IKeyboardInput>() == null)
            {
                _keyboardInput = null;
            }

            if (_speedModulus < 0)
            {
                _speedModulus = 0;
            }
        }

        private void Awake()
        {
            if (_keyboardInput != null)
            {
                _input = _keyboardInput.GetComponent<IKeyboardInput>();
            }

            _health = GetComponent<IHealth>();
            _selfBody = GetComponent<Rigidbody>();
            _attack = GetComponent<Attack>();
            _visitor = FindObjectOfType<DeathHandler>().GetComponent<IVisitor>();
        }

        private void OnEnable()
        {
            _input.Moved += OnMoved;
            _input.Pressed += OnPressed;
            _health.Died += OnDied;
        }

        private void OnDisable()
        {
            _input.Moved -= OnMoved;
            _input.Pressed -= OnPressed;
        }

        public Vector3? Position
        {
            get
            {
                if (_selfBody != null)
                {
                    return _selfBody.position;
                }

                return null;
            }
            
        }

        private void OnDied()
        {
            _visitor.Visit(this);
        }

        private void OnPressed()
        {
            if (_attack.TryAttack())
            {
                _attack.Shoot();
            }
        }


        private void OnMoved(Vector2 axis)
        {
            Vector3 direction = new Vector3(axis.x, 0f, axis.y);
            
            Vector3 velocity = direction * _speedModulus;

            _selfBody.velocity = velocity;
            
            LookAt(direction);
        }

        private void LookAt(Vector3 direction)
        {
            if(direction.Equals(Vector3.zero))
                return;
            
            Quaternion torque = Quaternion.LookRotation(direction, Vector3.up);

            _body.rotation = torque;
        }

   
    }
}