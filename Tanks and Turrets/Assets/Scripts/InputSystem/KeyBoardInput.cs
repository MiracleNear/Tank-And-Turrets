using System;
using UnityEngine;

namespace InputSystem
{
    public class KeyBoardInput : MonoBehaviour, IKeyboardInput
    {
        private Vector2 _inputAxis;
        
        public event Action Pressed;
        public event Action<Vector2> Moved;

        private void Start()
        {
            _inputAxis = Vector2.zero;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _inputAxis = Vector2.up;
                
                Moved?.Invoke(_inputAxis);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                _inputAxis = Vector2.down;
                
                Moved?.Invoke(_inputAxis);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                _inputAxis = Vector2.left;
                
                Moved?.Invoke(_inputAxis);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                _inputAxis = Vector2.right;
                
                Moved?.Invoke(_inputAxis);
            }
            else
            {
                _inputAxis = Vector2.zero;;
                
                Moved?.Invoke(_inputAxis);
            }

   
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Pressed?.Invoke();
            }
        }
    }
}